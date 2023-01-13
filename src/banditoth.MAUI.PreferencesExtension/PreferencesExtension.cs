using System.Text.Json;
using System.Text.Json.Serialization;

namespace banditoth.MAUI.PreferencesExtension;

// All the code in this file is included in all platforms.
public static class PreferencesExtension
{
    public static void SetObject<T>(string key, T obj)
    {
        SetObject<T>(Preferences.Default, key, obj);
    }

    public static void SetObject<T>(this IPreferences preferences, string key, T obj)
    {
        string jsonValue = null;

        if (obj != null)
        {
            jsonValue = JsonSerializer.Serialize<T>(obj);
        }

        preferences.Set<string>(key, jsonValue);
    }

    public static T GetObject<T>(string key, T defaultValue)
    {
        return GetObject<T>(Preferences.Default, key, defaultValue);
    }

    public static T GetObject<T>(this IPreferences preferences, string key, T defaultValue)
    {
        string jsonValue = preferences.Get<string>(key, null);

        if (jsonValue == null)
            return defaultValue;

        return JsonSerializer.Deserialize<T>(jsonValue);
    }
}

