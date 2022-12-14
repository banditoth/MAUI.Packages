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
#####                                        Jailbreak and root detection                                                    #####
#####                                                                                                                        #####
##################################################################################################################################

##### Contact #####

Bug report, feature request: https://github.com/banditoth/MAUI.Packages/issues
Source code: https://github.com/banditoth/MAUI.Packages/
My blog: https://www.banditoth.net/

##### Usage in a nutshell ######

-----------------
- Initalization -
-----------------

Initalize the plugin within your MauiProgram.cs's CreateMauiApp method. Use the .ConfigureJailbreakProtection extension method with the using banditoth.MAUI.JailbreakDetector;

		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureJailbreakProtection(configuration =>
				{
					configuration.MaximumPossibilityPercentage = 20;
					configuration.MaximumWarningCount = 1;
					configuration.CanThrowException = true;
				});

			return builder.Build();
		}

-----------------------
-       Usage         -
-----------------------

Configure your desired settings in the CreateMauiApp method.
See the possible configuration options at the Initalization section.
You can dependency inject the jailbreak detector instance, by resolving an instance of IJailbreakDetector.
Check IsSupported() to make sure that the current platform supports the detection algorithm or not.
If it is, you can use the detection methods.
By calling IsRootedOrJailbrokenAsync() the boolean result will be evaluated with your configuration options.
By calling ScanExploitsAsync you can process the discovered exploits and warnings during the scan - It returns a ScanResult.
ScanResult has a property named PossibilityPercentage.
This percentage tells you how confidently you can tell whether a device has been jailbroken or rooted.
Different types of tests contribute different weights to the final result.