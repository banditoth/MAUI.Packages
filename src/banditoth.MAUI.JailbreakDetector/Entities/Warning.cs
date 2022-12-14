using System;
using banditoth.MAUI.JailbreakDetector.Enumerations;

namespace banditoth.MAUI.JailbreakDetector.Entities
{
	public class Warning
	{
		public WarningType WarningType { get; set; }

		public string Path { get; set; }

		public Exception Exception { get; set; }
	}
}

