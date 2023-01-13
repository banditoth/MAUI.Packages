using banditoth.MAUI.DeviceId.Interfaces;

namespace banditoth.MAUI.DeviceId;

// All the code in this file is only included on Windows.
public partial class DeviceIdProvider
{
    public partial string GetDeviceId()
    {
        return Windows.System.Profile.SystemIdentification.GetSystemIdForPublisher()?.Id?.ToString();
    }
}

