using System;
using banditoth.MAUI.JailbreakDetector.Entities;
using banditoth.MAUI.JailbreakDetector.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace banditoth.MAUI.JailbreakDetector
{
	public static class MauiAppBuilderExtension
	{
        public static MauiAppBuilder ConfigureJailbreakProtection(this MauiAppBuilder builder, Action<IJailbreakDetectorConfiguration> configureDelegate)
        {
            IJailbreakDetectorConfiguration config = new JailbreakSettings();

            if (configureDelegate != null)
            {
                configureDelegate.Invoke(config);
            }

            builder.Services.TryAdd(new ServiceDescriptor(typeof(IJailbreakDetectorConfiguration), config));
            builder.Services.TryAddTransient(typeof(IJailbreakDetector), typeof(JailberakDetectorService));

            return builder;
        }
    }
}

