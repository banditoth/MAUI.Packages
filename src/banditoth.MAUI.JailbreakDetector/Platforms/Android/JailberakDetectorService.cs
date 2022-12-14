using Android.Content.PM;
using banditoth.MAUI.JailbreakDetector.Entities;
using banditoth.MAUI.JailbreakDetector.Exceptions;
using banditoth.MAUI.JailbreakDetector.Interfaces;

namespace banditoth.MAUI.JailbreakDetector;

// All the code in this file is only included on Android.
public class JailberakDetectorService : IJailbreakDetector
{
    private const int ShouldNotBeSuperUserScore = 20;
    private const int ShouldNotInstalledAppScore = 20;
    private const int ShouldNotWriteScore = 15;

    private readonly string[] ShouldNotWriteHere =
    {
        "/etc/",
        "/sbin/",
        "/system/",
        "/system/bin/",
        "/system/xbin/",
        "/system/sbin/",
    };

    private readonly string[] ShouldNotInstalledApps =
    {
        "com.formyhm.hideroot",
        "com.saurik.substrate",
        "com.amphoras.hidemyrootadfree",
        "com.amphoras.hidemyroot",
        "com.ramdroid.appquarantine",
        "com.koushikdutta.superuser",
        "com.noshufou.android.su.elite",
        "com.thirdparty.superuser",
        "com.zachspong.temprootremovejb",
        "com.chelpus.lackypatch",
        "com.chelpus.luckypatcher",
        "com.yellowes.su",
        "com.dimonvideo.luckypatcher",
        "com.topjohnwu.magisk",
        "com.koushikdutta.rommanager",
        "eu.chainfire.supersu"
    };

    private readonly string[] RootDirectories =
    {
        "/cache/",
        "/data/",
        "/dev/",
        "/sbin/",
        "/su/bin/",
        "/data/local/bin/",
        "/system/bin/",
        "/system/sd/xbin/",
        "/data/local/xbin/",
        "/system/xbin/"
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

            foreach (string rootDir in RootDirectories)
            {
                maxPossibilityScore += ShouldNotBeSuperUserScore;
                string path = rootDir + "su.apk";
                try
                {
                    if (File.Exists(path))
                    {
                        vulnerabilities.Add(new Exploit() { Path = path, VulnerabilityType = Enumerations.VulnerabilityType.SuperUserExecutableFound });
                        possibilityScore += ShouldNotBeSuperUserScore;
                    }
                }
                catch (Exception ex)
                {
                    warnings.Add(new Warning() { Exception = ex, WarningType = Enumerations.WarningType.UnableToCheckAppInstallation, Path = path });
                }
            }

            PackageManager packageManager = Microsoft.Maui.ApplicationModel.Platform.CurrentActivity.PackageManager;
            var allapps = packageManager.GetInstalledApplications(PackageInfoFlags.MetaData);

            foreach (string packagename in ShouldNotInstalledApps)
            {
                maxPossibilityScore += ShouldNotInstalledAppScore;
                try
                {
                    if (allapps.Any(z => z.PackageName == packagename))
                    {
                        vulnerabilities.Add(new Exploit() { VulnerabilityType = Enumerations.VulnerabilityType.AppInstalled, Path = packagename });
                        possibilityScore += ShouldNotInstalledAppScore;
                    }
                }
                catch (Exception ex)
                {
                    warnings.Add(new Warning() { Exception = ex, WarningType = Enumerations.WarningType.UnableToCheckAppInstallation, Path = packagename });
                }
            }

            foreach (string path in ShouldNotWriteHere)
            {
                maxPossibilityScore += ShouldNotWriteScore;
                try
                {
                    File.CreateText(path + DateTime.Today.ToString("yyyyMMddHHmmss") + ".txt");
                    vulnerabilities.Add(new Exploit() { VulnerabilityType = Enumerations.VulnerabilityType.CanCreateFile, Path = path });
                    possibilityScore += ShouldNotWriteScore;
                }
                catch
                {

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

