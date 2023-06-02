using System;
using System.Reflection;

namespace banditoth.MAUI.FontIcons.Interfaces
{
	public interface IFontIconProvider
	{
		void AddFont(string alias, string path, Assembly assembly);

		string GetGlyphByReadableName(string fontAlias, string name);
	}
}

