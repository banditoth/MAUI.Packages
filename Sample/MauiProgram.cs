using AnotherLibrary;
using banditoth.MAUI.Multilanguage;
using banditoth.MAUI.MVVM;
using Sample.Resources.Translations;
using Sample.ViewModels;
using Sample.Views;

namespace Sample;

public static class MauiProgram
{
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
				config.Register(typeof(MainScreenViewModel), typeof(MainScreenView));
				config.Register(typeof(AboutViewModel), typeof(AboutView));
			})
			.ConfigureMultilanguage(config =>
            {
				config.UseResource(SampleAppTranslations.ResourceManager);
				config.UseResource(AnotherLibraryTranslations.ResourceManager);

				// If the app is not storing last used culture, this culture will be used by default
				config.UseDefaultCulture(new System.Globalization.CultureInfo("en"));

				// Determines whether the app should store the last used culture
				config.StoreLastUsedCulture(true);

				// Determines whether the app should throw an exception if a translation is not found.
				config.ThrowExceptionIfTranslationNotFound(false);

				// You can set custom translation not found text by calling this method 
				config.SetTranslationNotFoundText("Transl_Not_Found:", appendTranslationKey: true);
			});

		return builder.Build();
	}
}
