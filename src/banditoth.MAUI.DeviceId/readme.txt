  _                     _ _ _        _   _     _       __  __         _    _ _____   _____           _                         
 | |                   | (_) |      | | | |   ( )     |  \/  |   /\  | |  | |_   _| |  __ \         | |                        
 | |__   __ _ _ __   __| |_| |_ ___ | |_| |__ |/ ___  | \  / |  /  \ | |  | | | |   | |__) |_ _  ___| | ____ _  __ _  ___  ___ 
 | '_ \ / _` | '_ \ / _` | | __/ _ \| __| '_ \  / __| | |\/| | / /\ \| |  | | | |   |  ___/ _` |/ __| |/ / _` |/ _` |/ _ \/ __|
 | |_) | (_| | | | | (_| | | || (_) | |_| | | | \__ \ | |  | |/ ____ \ |__| |_| |_ _| |  | (_| | (__|   < (_| | (_| |  __/\__ \
 |_.__/ \__,_|_| |_|\__,_|_|\__\___/ \__|_| |_| |___/ |_|  |_/_/    \_\____/|_____(_)_|   \__,_|\___|_|\_\__,_|\__, |\___||___/
                                                                                                                __/ |          
                                                                                                               |___/

##############################################################################################################
#####                                                                                                    #####
#####                                                 DeviceId                                           #####
#####                                                                                                    #####
##############################################################################################################

##### Contact #####

Bug report, feature request: https://github.com/banditoth/MAUI.Packages/issues
Source code: https://github.com/banditoth/MAUI.Packages/
My blog: https://www.banditoth.net/

##### Usage in a nutshell ######

-----------------
- Initalization -
-----------------

Initalize the plugin within your MauiProgram.cs's CreateMauiApp method. Use the .ConfigureDeviceIdProvider extension method with the using banditoth.MAUI.DeviceId;

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
            .ConfigureDeviceIdProvider();
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }


---------
- Usage -
---------

Use the code with by resolving an instance of IDeviceIdProvider.

The GetDeviceId method returns an unique device identifier. On Android it serves the data from AndroidId, on iOS and MacCatalyst it uses the IdentifierForVendor. Windows returns the GetSystemIdForPublisher().Id as a string.

The GetInstallationId method generates an unique identifier for the application, which will be stored until the application is being reinstalled, or the application's data being erased.