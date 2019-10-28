using Common.Localization;
using Foundation;
using System;
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
            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];

                netLanguage = iOSToDotnetLanguage(pref);
            }

            CultureInfo cultureInfo = null;
            try
            {
                cultureInfo = new CultureInfo(netLanguage);
            }
            catch (CultureNotFoundException e1)
            {
                try
                {
                    var fallback = ToDotnetFallbackLanguage(new PlatformCulture(netLanguage));
                    cultureInfo = new CultureInfo(fallback);
                }
                catch (CultureNotFoundException e2)
                {
                    cultureInfo = new CultureInfo("en");
                }
            }

            return cultureInfo;
        }

        private string iOSToDotnetLanguage(string iOSLanguage)
        {
            var netLanguage = iOSLanguage;

            switch (iOSLanguage)
            {
                case "ms-MY":   
                case "ms-SG":   
                    netLanguage = "ms"; 
                    break;
                case "gsw-CH":  
                    netLanguage = "de-CH"; 
                    break;
            }

            return netLanguage;
        }

        private string ToDotnetFallbackLanguage(PlatformCulture platformCulture)
        {
            var netLanguage = platformCulture.LanguageCode; 

            switch (platformCulture.LanguageCode)
            {
                case "pt":
                    netLanguage = "pt-PT"; 
                    break;
                case "gsw":
                    netLanguage = "de-CH"; 
                    break;
            }

            return netLanguage;
        }
    }
}