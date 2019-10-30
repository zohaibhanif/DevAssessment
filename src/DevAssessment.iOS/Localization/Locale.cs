using Common.Localization;
using Foundation;
using System.Globalization;
using System.Threading;
using DevAssessment.Extensions;

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
                if (!(this.IsLanguageSupported(netLanguage)))
                {
                    netLanguage = "en";
                }

                cultureInfo = new CultureInfo(netLanguage);
            }
            catch (CultureNotFoundException e1)
            {
                try
                {
                    var fallbackLanguage = new PlatformCulture(netLanguage).LanguageCode;

                    if (!(this.IsLanguageSupported(fallbackLanguage)))
                    {
                        fallbackLanguage = "en";
                    }

                    cultureInfo = new CultureInfo(fallbackLanguage);
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