using System;
using Microsoft.Maui.Controls;

namespace banditoth.MAUI.MVVM.Entities
{
    public class BaseView : ContentPage
    {
        public BaseView()
        {

        }

        protected override void OnAppearing()
        {
            if (BindingContext is BaseViewModel viewModel)
            {
                viewModel.OnViewAppearing();
            }

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            if (BindingContext is BaseViewModel viewModel)
            {
                viewModel.OnViewDisapearing();
            }

            base.OnDisappearing();
        }

        protected override bool OnBackButtonPressed()
        {
            if(OnBackButtonPressedCommand?.CanExecute(null) == true)
            {
                OnBackButtonPressedCommand.Execute(null);
                return true;
            }

            return base.OnBackButtonPressed();
        }

        BindableProperty OnBackButtonPressedCommandProperty = BindableProperty.Create
            (
                propertyName: nameof(OnBackButtonPressedCommand),
                returnType: typeof(Command),
                declaringType: typeof(BaseView),
                defaultValue : null
            );

        public Command OnBackButtonPressedCommand
        {
            get => (Command)GetValue(OnBackButtonPressedCommandProperty);
            set => SetValue(OnBackButtonPressedCommandProperty, value);
        }    
    }
}

