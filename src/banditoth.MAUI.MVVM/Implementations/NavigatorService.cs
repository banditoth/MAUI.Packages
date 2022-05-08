using System;
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

        public Page GetInstance<TViewmodel>(Action<TViewmodel, Page> initialiser = null, bool initalizeOnDifferentThread = true) where TViewmodel : BaseViewModel
        {
            if (connector.IsContainsViewModel(typeof(TViewmodel)) == false)
            {
                throw new Exception($"The ({typeof(TViewmodel)}) is not registered. Register it using ConfigureMvvm method in MauiApp.cs");
            }

            Type pageType = connector.GetViewType(typeof(TViewmodel));
            Page pageInstance = (Page)serviceProvider.GetService(pageType);
            TViewmodel viewModelInstance = (TViewmodel)serviceProvider.GetService(typeof(TViewmodel));

            pageInstance.BindingContext = viewModelInstance;
            viewModelInstance.SetNavigation(pageInstance.Navigation);

            if (initialiser != null)
            {
                if (initalizeOnDifferentThread)
                    _ = Task.Run(() => initialiser.Invoke(viewModelInstance, pageInstance));
                else
                    initialiser.Invoke(viewModelInstance, pageInstance);
            }

            return pageInstance;
        }
    }
}

