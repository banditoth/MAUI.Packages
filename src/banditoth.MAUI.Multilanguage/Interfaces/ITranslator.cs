using System.Globalization;
using System.Resources;
namespace banditoth.MAUI.Multilanguage.Interfaces
{
	public interface ITranslator
	{
		CultureInfo CurrentCulture { get; }

		void SetCurrentCulture(CultureInfo culture);

		string GetTranslation(string key);
	}
}

