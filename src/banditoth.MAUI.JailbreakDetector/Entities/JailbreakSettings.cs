using System;
using banditoth.MAUI.JailbreakDetector.Interfaces;

namespace banditoth.MAUI.JailbreakDetector.Entities
{
    public class JailbreakSettings : IJailbreakDetectorConfiguration
    {
        public double MaximumPossibilityPercentage { get; set; }

        public int MaximumWarningCount { get; set; }

        public bool CanThrowException { get; set; }
	}
}

