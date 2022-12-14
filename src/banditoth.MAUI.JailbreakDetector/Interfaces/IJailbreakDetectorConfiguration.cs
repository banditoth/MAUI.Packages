using System;
namespace banditoth.MAUI.JailbreakDetector.Interfaces
{
	public interface IJailbreakDetectorConfiguration
    {
        double MaximumPossibilityPercentage { get; set; }

        int MaximumWarningCount { get; set; }

        bool CanThrowException { get; set; }
    }
}

