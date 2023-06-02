using System;
using banditoth.MAUI.FontIcons.Interfaces;

namespace banditoth.MAUI.FontIcons
{
	public static class FontCollectionExtension
	{
		public static void UseFontsAsFontIcons(this IFontCollection collection, IServiceProvider serviceProvider)
		{
			var provider = serviceProvider.GetService<IFontIconProvider>();

			foreach (var font in collection)
			{
				provider.AddFont(font.Alias, font.Filename, font.Assembly);
			}
		}
	}
}

