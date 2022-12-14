using System;
namespace banditoth.MAUI.JailbreakDetector.Entities
{
	public class ScanResult
	{
		public IEnumerable<Exploit> Exploits { get; internal set; }

        public IEnumerable<Warning> Warnings { get; internal set; }

        public double PossibilityPercentage { get; internal set; }
    }
}

