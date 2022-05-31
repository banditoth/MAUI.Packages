using System;
using System.Diagnostics;
using banditoth.MAUI.MVVM.Entities;
using CommunityToolkit.Mvvm.Input;

namespace Sample.ViewModels
{
	public partial class AboutViewModel : BaseViewModel
	{
		public AboutViewModel()
		{

		}

		[ICommand]
		private async Task OpenGithubPage()
        {
            try
            {
                await Browser.OpenAsync("https://github.com/banditoth/MAUI.Packages");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
	}
}

