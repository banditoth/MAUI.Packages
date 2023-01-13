using banditoth.MAUI.DeviceId.Interfaces;
using static Android.Provider.Settings;

namespace banditoth.MAUI.DeviceId;
// All the code in this file is only included on Android.
public partial class DeviceIdProvider
{
    public partial string GetDeviceId()
    {
        return Android.Provider.Settings.Secure.GetString(Android.App.Application.Context.ContentResolver, Secure.AndroidId);
    }
}

