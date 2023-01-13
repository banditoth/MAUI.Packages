using banditoth.MAUI.DeviceId.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace banditoth.MAUI.DeviceId;

// All the code in this file is included in all platforms.
public static class MauiAppBuilderExtension
{
    public static MauiAppBuilder ConfigureDeviceIdProvider(this MauiAppBuilder builder)
    {
        builder.Services.Add(new ServiceDescriptor(typeof(IDeviceIdProvider), typeof(DeviceIdProvider), ServiceLifetime.Transient));

        return builder;
    }
}

