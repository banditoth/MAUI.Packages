using System;
using System.Reflection;
using banditoth.MAUI.FontIcons.Interfaces;
using SharpFont;

namespace banditoth.MAUI.FontIcons.Implementations
{
	public class FontIconProvider : IFontIconSettings, IFontIconProvider
	{
		private List<Microsoft.Maui.Hosting.FontDescriptor> _fontDescriptors = new List<Microsoft.Maui.Hosting.FontDescriptor>();

		public FontIconProvider()
		{
		}

        public void AddFont(string alias, string path, Assembly assembly)
        {
            _fontDescriptors.Add(new FontDescriptor(path, alias, assembly));
        }

        public string GetGlyphByReadableName(string fontAlias, string name)
        {
            FontDescriptor fontDescriptor = _fontDescriptors.FirstOrDefault(fd => fd.Alias == fontAlias);

            if (fontDescriptor != null)
            {
                
            }
        }
    }
}

