using banditoth.MAUI.JailbreakDetector.Entities;
using banditoth.MAUI.JailbreakDetector.Exceptions;
using banditoth.MAUI.JailbreakDetector.Interfaces;

namespace banditoth.MAUI.JailbreakDetector;

// All the code in this file is only included on iOS.
public class JailberakDetectorService : IJailbreakDetector
{
    private const int ShouldNotExistDirectoryScore = 20;
    private const int ShouldNotInstalledAppScore = 15;
    private const int ShouldNotWriteHereScore = 10;
    private const int ShouldNotOpenDeeplinkScore = 5;

    private readonly string[] ShouldNotExistDirectories =
    {
        "/private/var/cache/apt",
        "/private/var/lib/apt",
        "/var/lib/apt",
        "/private/etc/apt",
        "/etc/apt",
        "/private/cache/apt",
        "/var/lib/cydia",
        "/usr/libexec/cydia",
        "/private/var/lib/cydia",
        "/private/var/db/stash",
        "/private/var/stash",
        "/private/var/mobileLibrary/SBSettingsThemes",
        "/private/etc/mobileLibrary/SBSettingsThemes"
    };


    private readonly string[] ShouldNotInstalledApps =
    {
        "/Applications/Cydia.app",
        "/private/var/tmp/cydia.log",
        "/Applications/blackra1n.app",
        "/Applications/SBSettings.app",
        "/Applications/WinterBoard.app",
    };

    private readonly string[] ShouldNotListenForDeeplink =
    {
        "cydia://package/com.banditoth.MAUI"
    };

    private readonly string[] ShouldNotWriteHere =
    {
        "/private/",
    };

    private readonly IJailbreakDetectorConfiguration _configuration;

    public JailberakDetectorService(IJailbreakDetectorConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async ValueTask<ScanResult> ScanExploitsAsync()
    {
        try
        {
            List<Exploit> vulnerabilities = new List<Exploit>();
            List<Warning> warnings = new List<Warning>();
            double possibilityScore = 0;
            double maxPossibilityScore = 0;

            foreach (string directoryPath in ShouldNotExistDirectories)
            {
                maxPossibilityScore += ShouldNotExistDirectoryScore;
                try
                {
                    if (Directory.Exists(directoryPath))
                    {
                        vulnerabilities.Add(new Exploit() { VulnerabilityType = Enumerations.VulnerabilityType.DirectoryExists, Path = directoryPath });
                        possibilityScore += ShouldNotExistDirectoryScore;
                    }
                }
                catch (Exception ex)
                {
                    warnings.Add(new Warning() { Exception = ex, WarningType = Enumerations.WarningType.UnableToCheckDirectoryExistance, Path = directoryPath });
                }
            }

            foreach (string appPath in ShouldNotInstalledApps)
            {
                maxPossibilityScore += ShouldNotInstalledAppScore;
                try
                {
                    if (File.Exists(appPath))
                    {
                        vulnerabilities.Add(new Exploit() { VulnerabilityType = Enumerations.VulnerabilityType.AppInstalled, Path = appPath });
                        possibilityScore += ShouldNotInstalledAppScore;
                    }
                }
                catch (Exception ex)
                {
                    warnings.Add(new Warning() { Exception = ex, WarningType = Enumerations.WarningType.UnableToCheckAppInstallation, Path = appPath });
                }
            }

            foreach (string path in ShouldNotWriteHere)
            {
                maxPossibilityScore += ShouldNotWriteHereScore;
                try
                {
                    File.CreateText(path + DateTime.Today.ToString("yyyyMMddHHmmss") + ".txt");
                    vulnerabilities.Add(new Exploit() { VulnerabilityType = Enumerations.VulnerabilityType.CanCreateFile, Path = path });
                    possibilityScore += ShouldNotWriteHereScore;
                }
                catch
                {

                }
            }

            foreach (string deeplinkUri in ShouldNotListenForDeeplink)
            {
                maxPossibilityScore += ShouldNotOpenDeeplinkScore;
                try
                {
                    if (await Launcher.CanOpenAsync(deeplinkUri))
                    {
                        vulnerabilities.Add(new Exploit() { VulnerabilityType = Enumerations.VulnerabilityType.CanOpenDeeplink, Path = deeplinkUri });
                        possibilityScore += ShouldNotOpenDeeplinkScore;
                    }
                }
                catch (Exception ex)
                {
                    warnings.Add(new Warning() { Exception = ex, WarningType = Enumerations.WarningType.UnableToCheckDeeplink, Path = deeplinkUri });
                }
            }

            return new ScanResult()
            {
                Exploits = vulnerabilities,
                Warnings = warnings,
                PossibilityPercentage = possibilityScore / maxPossibilityScore * 100
            };
        }
        catch (Exception globalEx)
        {
            if (_configuration.CanThrowException)
                throw new JailbreakDetectorException(globalEx);

            return null;
        }
    }

    public async ValueTask<bool> IsRootedOrJailbrokenAsync()
    {
        ScanResult result = await ScanExploitsAsync();

        return result.PossibilityPercentage >= _configuration.MaximumPossibilityPercentage;
    }

    public bool IsSupported() => true;

}

