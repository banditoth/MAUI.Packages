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
#####                                     PreferencesExtension                                           #####
#####                                                                                                    #####
##############################################################################################################

##### Contact #####

Bug report, feature request: https://github.com/banditoth/MAUI.Packages/issues
Source code: https://github.com/banditoth/MAUI.Packages/
My blog: https://www.banditoth.net/

---------
- Usage -
---------

This code is extending the basic functions of the built in MAUI Essentials IPreferences by letting the developers to save any type of object.
This is done by using JSON serialization, and saving the raw jsons as strings with the default IPreferences implementation.
Please consider saving large objects with it.
Since JSON arrays can be serialized back to any collection type, you can use different types when Setting the value and when Getting it back.

*** 1. Method - Dependency injection ***

If you used to dependency inject the IPreferences class, you can use this tool without any differencies. Call the SetObject or GetObject extension method on the IPreferences.

    private readonly IPreferences preferences;

    public MainPage(IPreferences preferences)
    {
        InitializeComponent();
        this.preferences = preferences;
    }

    private void Foo()
    {
        List<string> taleItems = new List<string>()
        {
            "The quick brown fox",
            "Jumps over the lazy dog"
        };

        preferences.SetObject<List<string>>("Tale", taleItems);

        string[] taleItemsFromPreferences = preferences.GetObject<string[]>("Tale", null);
    }


*** 2. Method - Static preferences ***

If you are used to access the preferences trough the static class, you can use this tool by accessing the Default property on the Preferences class. You can call the SetObject or GetObject extension method on it.

            // Setting the value
            Preferences.Default.SetObject<IDeviceInfo>("Device_Information", DeviceInfo.Current);
            // Getting the value
            Preferences.Default.GetObject<IDeviceInfo>("Device_Information", null);
*** 3. Method - Custom static class ***

You can also access the SetObject or GetObject method on PreferencesExtension static class.

            // Setting the value
            PreferencesExtension.SetObject<DisplayOrientation>("Last_Display_Orientation", orientation);
            // Getting the value
            PreferencesExtension.GetObject<DisplayOrientation>("Last_Display_Orientation", DisplayOrientation.Landscape);
