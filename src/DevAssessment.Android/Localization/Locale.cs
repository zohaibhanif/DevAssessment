using Common.Localization;
using System;
using System.Globalization;
using System.Threading;

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
            netLanguage = AndroidToDotnetLanguage(androidLocale.ToString().Replace("_", "-"));

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

        private string AndroidToDotnetLanguage(string androidLanguage)
        {
            Console.WriteLine("Android Language:" + androidLanguage);
            var netLanguage = androidLanguage;

            switch (androidLanguage)
            {
                case "ms-BN":   
                case "ms-MY":   
                case "ms-SG":   
                    netLanguage = "ms";
                    break;
                case "in-ID":  
                    netLanguage = "id-ID"; 
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
                case "gsw":
                    netLanguage = "de-CH"; 
                    break;
            }

            return netLanguage;
        }
    }
}