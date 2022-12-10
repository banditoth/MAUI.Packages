using System;
using banditoth.MAUI.JailbreakDetector.Entities;
using banditoth.MAUI.JailbreakDetector.Interfaces;

namespace banditoth.MAUI.JailbreakDetector;

public class JailbreakDetectorService : IJailbreakDetector
{
    public JailbreakDetectorService()
    {
    }

    public ValueTask<ScanResult> GetVulnerabilities()
    {
        throw new PlatformNotSupportedException("This platform is not supported");
    }

    public ValueTask<bool> IsRootedOrJailbroken()
    {
        throw new PlatformNotSupportedException("This platform is not supported");
    }

    public bool IsSupported() => false;
}

