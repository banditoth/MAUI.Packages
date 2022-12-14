using System;
using banditoth.MAUI.JailbreakDetector.Entities;

namespace banditoth.MAUI.JailbreakDetector.Interfaces
{
	public interface IJailbreakDetector
	{
		bool IsSupported();

		ValueTask<bool> IsRootedOrJailbrokenAsync();

        ValueTask<ScanResult> ScanExploitsAsync();
    }
}

