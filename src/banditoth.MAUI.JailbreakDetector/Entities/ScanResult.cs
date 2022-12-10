using System;
namespace banditoth.MAUI.JailbreakDetector.Entities
{
	public class ScanResult
	{
		public IEnumerable<Vulnerability> Vulnerabilities { get; internal set; }

        public IEnumerable<Warning> Warnings { get; internal set; }

		public double PossibilityScore { get; internal set; }

        public double PossibilityPercentage { get; internal set; }
    }
}

