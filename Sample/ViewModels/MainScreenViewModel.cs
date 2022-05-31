using System;
using System.Diagnostics;
using banditoth.MAUI.Multilanguage.Interfaces;
using banditoth.MAUI.MVVM.Entities;
using banditoth.MAUI.MVVM.Interfaces;
using CommunityToolkit.Mvvm.Input;

namespace Sample.ViewModels
{
	public partial class MainScreenViewModel : BaseViewModel
	{
        private readonly INavigator navigator;
        private readonly ITranslator translator;

        public MainScreenViewModel(INavigator navigator, ITranslator translator)
		{
            this.navigator = navigator;
            this.translator = translator;
        }

		internal async Task Initalize()
        {
			
        }

		[ICommand]
		private async Task DisplayAboutPage()
		{
            try
            {
                await Navigation.PushAsync(navigator.GetInstance<AboutViewModel>());
            }
            catch (Exception ex)
            {
				Debug.WriteLine(ex);
            }
		}

		[ICommand]
        private async Task ChangeLanguage()
        {
            try
            {
                switch (translator.CurrentCulture.Name.ToLower())
                {
                    case "en-us":
                        translator.SetCurrentCulture(new System.Globalization.CultureInfo("de"));
                        break;
                    case "de-es":
                        translator.SetCurrentCulture(new System.Globalization.CultureInfo("es"));
                        break;
                    default:
                    case "es-es":
                        translator.SetCurrentCulture(new System.Globalization.CultureInfo("en"));
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
	}
}

