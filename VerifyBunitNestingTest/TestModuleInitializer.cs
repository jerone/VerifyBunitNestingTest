using System.Globalization;
using System.Runtime.CompilerServices;
using Argon;

namespace VerifyBunitNestingTest;

/// <summary>
/// Class for initializing the test module, like Verify tool.
/// </summary>
public static class TestModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        // Set culture to Dutch (Netherlands) for consistent formatting in tests.
        var culture = new CultureInfo("nl-NL");
        Thread.CurrentThread.CurrentCulture = culture;
        Thread.CurrentThread.CurrentUICulture = culture;

        // Allow verification of AspNetCore bits.
        VerifyAspNetCore.Initialize();

        // Don't scrub DateTimes.
        VerifierSettings.DontScrubDateTimes();

        // Don't scrub Guids.
        VerifierSettings.DontScrubGuids();

        // Ignore stack traces.
        VerifierSettings.IgnoreStackTrace();

        VerifierSettings.AddExtraSettings(settings =>
            // Export all properties, including those with default values.
            // This is to guard that the "contract" (what is output by the API) doesn't change.
            settings.DefaultValueHandling = DefaultValueHandling.Include
        );

        // Use real JSON.
        VerifierSettings.UseStrictJson();

        // BUnit support.
        VerifyBunit.Initialize();
    }
}
