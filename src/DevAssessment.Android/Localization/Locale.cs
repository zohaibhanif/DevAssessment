using Common.Localization;
using System;
using System.Globalization;
using System.Threading;
using DevAssessment.Extensions;

namespace DevAssessment.Droid.Localization
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
            var androidLocale = Java.Util.Locale.Default;
            netLanguage = androidLocale.Language;
            CultureInfo cultureInfo = null;

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