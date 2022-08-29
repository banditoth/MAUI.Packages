  _                     _ _ _        _   _     _       __  __         _    _ _____   _____           _                         
 | |                   | (_) |      | | | |   ( )     |  \/  |   /\  | |  | |_   _| |  __ \         | |                        
 | |__   __ _ _ __   __| |_| |_ ___ | |_| |__ |/ ___  | \  / |  /  \ | |  | | | |   | |__) |_ _  ___| | ____ _  __ _  ___  ___ 
 | '_ \ / _` | '_ \ / _` | | __/ _ \| __| '_ \  / __| | |\/| | / /\ \| |  | | | |   |  ___/ _` |/ __| |/ / _` |/ _` |/ _ \/ __|
 | |_) | (_| | | | | (_| | | || (_) | |_| | | | \__ \ | |  | |/ ____ \ |__| |_| |_ _| |  | (_| | (__|   < (_| | (_| |  __/\__ \
 |_.__/ \__,_|_| |_|\__,_|_|\__\___/ \__|_| |_| |___/ |_|  |_/_/    \_\____/|_____(_)_|   \__,_|\___|_|\_\__,_|\__, |\___||___/
                                                                                                                __/ |          
                                                                                                               |___/

##################################################################################################################################
#####                                                                                                                        #####
#####                                                       Multilanguage                                                    #####
#####                                                                                                                        #####
##################################################################################################################################

##### Contact #####

Bug report, feature request: https://github.com/banditoth/MAUI.Packages/issues
Source code: https://github.com/banditoth/MAUI.Packages/
My blog: https://www.banditoth.net/

##### Tutorial #####

Explained tutorial can be found here: https://www.banditoth.net/2022/08/29/net-maui-write-multilingual-apps-easily/

##### Usage in a nutshell ######

-----------------
- Initalization -
-----------------

Initalize the plugin within your MauiProgram.cs's CreateMauiApp method. Use the .ConfigureMultilanguage extension method with the using banditoth.MAUI.Multilanguage;

		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
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

-----------------------
- Usage in XAML files -
-----------------------

Start using translations in your XAML by adding reference to the clr-namespace and using the markup extension:

xmlns:multilanguage="clr-namespace:banditoth.MAUI.Multilanguage"
Whenever you need a translation, you can use:

<Label IsVisible="True"
       Text="{multilanguage:Translation Key=TranslationKey}"/>

---------------------
- Usage in cs files -
---------------------

Inject or resolve an ITranslator instance from the dependency continaer.

public string Foo()
{
	// Get the currently set culture
	if(translator.CurrentCulture.Name != "English")
		// Set the culture by calling SetCurrentCulture
		translator.SetCurrentCulture(new CultureInfo("en"));
	
	// Get the translation from resources
	return translator.GetTranslation("The_Translation_Key")
}
