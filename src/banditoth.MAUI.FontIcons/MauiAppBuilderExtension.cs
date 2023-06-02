using System;
using banditoth.MAUI.FontIcons.Implementations;
using banditoth.MAUI.FontIcons.Interfaces;

namespace banditoth.MAUI.FontIcons
{
	public static class MauiAppBuilderExtension
	{
        public static MauiAppBuilder ConfigureFontIcons(this MauiAppBuilder builder, Action<IFontIconSettings> settingsDelegate)
        {
            FontIconProvider provider = new FontIconProvider();

            settingsDelegate.Invoke(provider);

            builder.Services.AddSingleton(typeof(IFontIconProvider), svc => provider);

            return builder;
        }
    }
}

