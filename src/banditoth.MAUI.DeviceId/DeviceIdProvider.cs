using banditoth.MAUI.DeviceId.Interfaces;
using Microsoft.Maui.Controls.PlatformConfiguration;

#if ANDROID
using static Android.Provider.Settings;
#elif IOS || MACCATALYST
using UIKit;
#endif

namespace banditoth.MAUI.DeviceId
{
    public partial class DeviceIdProvider : IDeviceIdProvider
    {
        public string GetDeviceId()
        {
#if ANDROID
        return Android.Provider.Settings.Secure.GetString(Android.App.Application.Context.ContentResolver, Secure.AndroidId);
#elif IOS || MACCATALYST
        return UIDevice.CurrentDevice.IdentifierForVendor?.ToString();
#elif WINDOWS
            return Windows.System.Profile.SystemIdentification.GetSystemIdForPublisher()?.Id?.ToString();
#else
            return null;
#endif
        }

        public string GetInstallationId()
        {
            return Preferences.Get(MauiAppBuilderExtension.InstallationIdKey, null);
        }
    }
}