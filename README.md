<img src="https://raw.githubusercontent.com/banditoth/MAUI.Packages/main/icon.png" width="120" height="120"/>

# banditoth's MAUI.Packages 🏝

A toolkit for .NET MAUI, containing useful stuff to ease development for MAUI applications.

**Packages**

| Package name | NuGet status |
| --- | --- |
| banditoth.MAUI.MVVM | ![nuGet version](https://img.shields.io/nuget/vpre/banditoth.MAUI.MVVM) |
| banditoth.MAUI.Multilanguage | ![nuGet version](https://img.shields.io/nuget/vpre/banditoth.MAUI.Multilanguage) |
| banditoth.MAUI.JailbreakDetector | ![nuGet version](https://img.shields.io/nuget/vpre/banditoth.MAUI.JailbreakDetector) |

**Azure DevOps**

[![Build Status](https://dev.azure.com/bitfoxhungary/MAUI.Packages/_apis/build/status/banditoth.MAUI.Packages?branchName=main)](https://dev.azure.com/bitfoxhungary/MAUI.Packages/_build/latest?definitionId=8&branchName=main)

[View Build pipeline on AzureDevOps](https://dev.azure.com/bitfoxhungary/MAUI.Packages/_build)

## banditoth.MAUI.Multilanguage

![nuGet version](https://img.shields.io/nuget/vpre/banditoth.MAUI.Multilanguage)
![Nuget](https://img.shields.io/nuget/dt/banditoth.MAUI.Multilanguage)
[View package on NuGet.org](https://www.nuget.org/packages/banditoth.MAUI.Multilanguage/)

A multilanguage translation provider for XAML and for code behind.

**Tutorial**

A full tutorial can be found here [https://www.banditoth.net/2022/08/29/net-maui-write-multilingual-apps-easily/](https://www.banditoth.net/2022/08/29/net-maui-write-multilingual-apps-easily/)

**Usage**

Create your ```resx``` files in your solution. For example if your applications default language is English, create a ```Translations.en.resx``` file, which contains the english translations, and if you want to support Hungarian language, you need to create a ```Translations.hu.resx``` file, which will contain the hungarian key value pairs.
You can add different resx files, also from different assembly. Just call the ```UseResource``` when initalizing the plugin multiple times.

Usage in cs files:
Inject or resolve an ITranslator instance from the dependency continaer.

```cs
public string Foo()
{
	// Get the currently set culture
	if(translator.CurrentCulture.Name != "English")
		// Set the culture by calling SetCurrentCulture
		translator.SetCurrentCulture(new CultureInfo("en"));
	
	// Get the translation from resources
	return translator.GetTranslation("The_Translation_Key")
}
```


Usage in XAML files:
Start using translations in your XAML by adding reference to the ```clr-namespace``` and using the markup extension:

```xml
xmlns:multilanguage="clr-namespace:banditoth.MAUI.Multilanguage"
```

Whenever you need a translation, you can use:

```xml
<Label IsVisible="True"
       Text="{multilanguage:Translation Key=TranslationKey}"/>
```

**Initalization**

Initalize the plugin within your ```MauiProgram.cs```'s ```CreateMauiApp``` method.
Use the ```.ConfigureMultilanguage``` extension method with the ```using banditoth.MAUI.Multilanguage```;

```cs
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder()
				.UseMauiApp<App>()
				...
				.ConfigureMultilanguage(config =>
				{
					// Set the source of the translations
					// You can use multiple resource managers by calling UseResource multiple times.
					config.UseResource(YourAppResource.ResourceManager);
					config.UseResource(YourAnotherAppResource.ResourceManager);

					// If the app is not storing last used culture, this culture will be used by default
					config.UseDefaultCulture(new System.Globalization.CultureInfo("en-US"));

					// Determines whether the app should store the last used culture
					config.StoreLastUsedCulture(true);

					// Determines whether the app should throw an exception if a translation is not found.
					config.ThrowExceptionIfTranslationNotFound(false);

					// You can set custom translation not found text by calling this method 
					config.SetTranslationNotFoundText("Transl_Not_Found:", appendTranslationKey: true);
				});

			return builder.Build();
		}
```

## banditoth.MAUI.JailbreakDetector

![nuGet version](https://img.shields.io/nuget/vpre/banditoth.MAUI.JailbreakDetector)
![Nuget](https://img.shields.io/nuget/dt/banditoth.MAUI.JailbreakDetector)
[View package on NuGet.org](https://www.nuget.org/packages/banditoth.MAUI.JailbreakDetector/)

A lightweight root and jailbreak detection algorithm for Android and iOS with .NET MAUI.

**Usage**

Configure your desired settings in the  ```CreateMauiApp``` method. See the possible configuration options at the Initalization section. You can dependency inject the jailbreak detector instance, by resolving an instance of ```IJailbreakDetector```. Check ```IsSupported()``` to make sure that the current platform supports the detection algorithm or not. If it is, you can use the detection methods.
By calling ```IsRootedOrJailbrokenAsync()``` the boolean result will be evaluated with your configuration options. By calling ```ScanExploitsAsync``` you can process the discovered exploits and warnings during the scan - It returns a ```ScanResult```.
```ScanResult``` has a property named ```PossibilityPercentage```. This percentage tells you how confidently you can tell whether a device has been jailbroken or rooted. Different types of tests contribute different weights to the final result. 

**Initalization**

```cs
public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder()
				.UseMauiApp<App>()
				...
				.ConfigureJailbreakProtection(configuration =>
				{
					configuration.MaximumPossibilityPercentage = 20;
					configuration.MaximumWarningCount = 1;
					configuration.CanThrowException = true;
				});
			return builder.Build();
		}
```


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
