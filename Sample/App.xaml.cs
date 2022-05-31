using banditoth.MAUI.MVVM.Interfaces;
using Sample.ViewModels;

namespace Sample;

public partial class App : Application
{
	public App(INavigator navigator)
	{
		InitializeComponent();

		MainPage = navigator.GetInstance<MainScreenViewModel>((vm,v)=>
        {
			vm.Initalize();
        });
	}
}
