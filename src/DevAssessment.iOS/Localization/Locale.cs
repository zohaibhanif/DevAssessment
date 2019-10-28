using Common.Localization;
using Foundation;
using System.Globalization;
using System.Threading;

namespace DevAssessment.iOS.Localization
{
    public class Locale : ILocale
    {
        public void SetLocale(CultureInfo cultureInfo)
        {
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        public CultureInfo GetCurrentCultureInfo()
        {
            var netLanguage = "en";
            CultureInfo cultureInfo = null;

            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                netLanguage = pref;
            }

            try
            {
                cultureInfo = new CultureInfo(netLanguage);
            }
            catch (CultureNotFoundException e1)
            {
                try
                {
                    var fallback = new PlatformCulture(netLanguage).LanguageCode;
                    cultureInfo = new CultureInfo(fallback);
                }
                catch (CultureNotFoundException e2)
                {
                    cultureInfo = new CultureInfo("en");
                }
            }

            return cultureInfo;
        }
    }
}