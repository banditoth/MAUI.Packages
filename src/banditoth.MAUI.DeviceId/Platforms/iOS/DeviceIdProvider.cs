using banditoth.MAUI.DeviceId.Interfaces;
using UIKit;

namespace banditoth.MAUI.DeviceId;

// All the code in this file is only included on iOS.
public partial class DeviceIdProvider
{
    public partial string GetDeviceId()
    {
        return UIDevice.CurrentDevice.IdentifierForVendor?.ToString();
    }
}

