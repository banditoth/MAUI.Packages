using System;
using banditoth.MAUI.FontIcons.Interfaces;

namespace banditoth.MAUI.FontIcons
{
    [ContentProperty(nameof(GlyphName))]
    public class FontIconExtension : IMarkupExtension<string>
    {
        public FontIconExtension()
        {

        }

        public string FontFamily { get; set; }

        public string GlyphName { get; set; }

        public string ProvideValue(IServiceProvider serviceProvider)
        {
            var provider = serviceProvider.GetService<IFontIconProvider>();
            return provider.GetGlyphByReadableName(FontFamily, GlyphName);
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }
    }
}

