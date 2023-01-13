using banditoth.MAUI.DeviceId.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace banditoth.MAUI.DeviceId;

// All the code in this file is included in all platforms.
public static class MauiAppBuilderExtension
{
    internal const string InstallationIdKey = "banditoth.MAUI.DeviceId.InstallationId";

    public static MauiAppBuilder ConfigureDeviceIdProvider(this MauiAppBuilder builder)
    {
        builder.Services.Add(new ServiceDescriptor(typeof(IDeviceIdProvider), typeof(DeviceIdProvider), ServiceLifetime.Transient));

        if (Preferences.Get(InstallationIdKey, null) == null)
            Preferences.Set(InstallationIdKey, Guid.NewGuid().ToString());

        return builder;
    }
}

