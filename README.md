<img src="https://raw.githubusercontent.com/banditoth/MAUI.Packages/main/icon.png" width="120" height="120"/>

# banditoth's MAUI.Packages 🏝

A toolkit for .NET MAUI, containing useful stuff to ease development for MAUI applications.

**Packages**

| Package name | NuGet status |
| --- | --- |
| banditoth.MAUI.MVVM | ![nuGet version](https://img.shields.io/nuget/vpre/banditoth.MAUI.MVVM) |
| banditoth.MAUI.Multilanguage | ![nuGet version](https://img.shields.io/nuget/vpre/banditoth.MAUI.Multilanguage) |

**Azure DevOps**

![Azure DevOps builds](https://img.shields.io/azure-devops/build/bitfoxhungary/MAUI.Packages/5?label=Build%20status)

[View Build pipeline on AzureDevOps](https://dev.azure.com/bitfoxhungary/MAUI.Packages/_build)

## banditoth.MAUI.MVVM
![nuGet version](https://img.shields.io/nuget/vpre/banditoth.MAUI.MVVM)
![Nuget](https://img.shields.io/nuget/dt/banditoth.MAUI.MVVM)
[View package on NuGet.org](https://www.nuget.org/packages/banditoth.MAUI.MVVM/)

A ViewModel first driven MVVM Library.

**Usage**

If you want to get an instance of a page, just simply inject or resolve an ```INavigator``` instance and call

```cs
navigator.GetInstance<ExampleViewModel>();
```

If you want to pass parameters from one ViewModel to an another, make an internal or a public method to your ViewModel class (I do usually call it ```Initalize```), and get the instance like this:

```cs
navigator.GetInstance<ExampleViewModel>((viewModel, view) =>
{
  // Invoke public methods of ViewModel from here 
  viewModel.Initalize(dataToBePassed);
  // View is also accessible here.
  view.IsEnabled = false;
});
```

If the Initalizer delegate should not run on the ```ThreadPool```, give false value to the ```initalizeOnDifferentThread``` parameter

You do not have to always register your View and ViewModel connections. You can use the following snippet to get page instances, which are not ```Register```ed it the ```.ConfigureMvvm``` call.

```cs
navigator.GetInstance<ExampleViewModel,ExampleView>();
```

Derive your ViewModels from the ```BaseViewModel``` class, which gives you the following advantages:
You can override the following methods in the derived viewmodel classes, which gets executed as the method name says
- ```OnViewAppearing```
- ```OnViewDissapearing```
- ```OnBackButtonPressed```
The View's ```Navigation``` property is automatically passed to the ViewModel's ```Navigation``` property

**Initalization**

Initalize the plugin within your ```MauiProgram.cs```'s ```CreateMauiApp``` method.
Use the ```.ConfigureMvvm``` extension method with the ```using banditoth.MAUI.MVVM```;
Register the ViewModel and View connections with the configuration builder's ```Register``` method.

```cs
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.ConfigureMvvm(config =>
            {
				// To register view and viewmodel connections
				config.Register(typeof(Example1ViewModel), typeof(AnotherPage));
				// To remove a connection
				config.Remove(typeof(Example1ViewModel));
				// You can make conditions with the IsContainsViewModel method
				bool isContaining = config.IsContainsViewModel(typeof(Example2ViewModel));
            });

		return builder.Build();
	}
```

# Icon

https://www.flaticon.com/free-icons/responsive"
Responsive icons created by rukanicon - Flaticon
