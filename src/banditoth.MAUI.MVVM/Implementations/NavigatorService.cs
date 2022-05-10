using System;
using System.Diagnostics;
using System.Threading.Tasks;
using banditoth.MAUI.MVVM.Entities;
using banditoth.MAUI.MVVM.Interfaces;
using Microsoft.Maui.Controls;

namespace banditoth.MAUI.MVVM.Implementations
{
    internal class NavigatorService : INavigator
    {
        private readonly IViewModelConnector connector;
        private readonly IServiceProvider serviceProvider;

        public NavigatorService(IViewModelConnector connector, IServiceProvider serviceProvider)
        {
            this.connector = connector;
            this.serviceProvider = serviceProvider;
        }

        public Page GetInstance<TViewmodel>() where TViewmodel : BaseViewModel
        {
            return GetInstance<TViewmodel>(null, false);
        }

        public Page GetInstance<TViewModel>(Action<TViewModel, Page> initialiser, bool initalizeOnDifferentThread = true) where TViewModel : BaseViewModel
        {
            if (connector.IsContainsViewModel(typeof(TViewModel)) == false)
            {
                throw new Exception($"The ({typeof(TViewModel)}) is not registered. Register it using ConfigureMvvm method in MauiApp.cs");
            }

            Type pageType = connector.GetViewType(typeof(TViewModel));

            if (pageType == null)
            {
                throw new Exception("Could not determine View type for ViewModel: " + typeof(TViewModel).AssemblyQualifiedName);
            }

            return GetInstance(typeof(TViewModel), pageType, initialiser != null ? (vm, v) => { initialiser?.Invoke((TViewModel)vm, v); } : null, initalizeOnDifferentThread);
        }


        public Page GetInstance<TViewModel, TView>(Action<TViewModel, TView> initialiser, bool initalizeOnDifferentThread = true) where TViewModel : BaseViewModel where TView : Page
        {
            return GetInstance(typeof(TViewModel), typeof(TView), initialiser != null ? (vm, v) => { initialiser.Invoke((TViewModel)vm, (TView)v); } : null, initalizeOnDifferentThread);
        }

        public Page GetInstance<TViewModel, TView>()
        {
            return GetInstance(typeof(TViewModel), typeof(TView), null, false);
        }

        private object ResolveInstance(Type type)
        {
            object instance = serviceProvider.GetService(type);

            if (instance == null)
            {
                Debug.WriteLine($"{nameof(GetInstance)} could not resolve type from the ServiceProvider! Trying with Activator instead. Type: " + type.Name);

                try
                {
                    instance = Activator.CreateInstance(type);
                }
                catch (Exception ex)
                {
                    throw new Exception($"The type of {type.AssemblyQualifiedName} can not be created, because its not registered in the ServiceProvider, and can not be created with activator.", ex);
                }
            }

            return instance;
        }

        private Page GetInstance(Type viewModelType, Type viewType, Action<BaseViewModel, Page> initialiser, bool initalizeOnDifferentThread)
        {
            Page pageInstance = (Page)ResolveInstance(viewType);
            BaseViewModel viewModelInstance = (BaseViewModel)ResolveInstance(viewModelType);

            pageInstance.BindingContext = viewModelInstance;
            viewModelInstance.SetNavigation(pageInstance.Navigation);

            if (initialiser == null)
                return pageInstance;

            if (initalizeOnDifferentThread)
            {
                _ = Task.Run(() => initialiser.Invoke(viewModelInstance, pageInstance));
            }
            else
            {
                initialiser.Invoke(viewModelInstance, pageInstance);
            }

            return pageInstance;
        }




    }
}

