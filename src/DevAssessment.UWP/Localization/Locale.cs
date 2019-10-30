using Common.Localization;
using System.Globalization;
using System.Threading;
using DevAssessment.Extensions;

namespace DevAssessment.UWP.Localization
{
    public class Locale : ILocale
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var netLanguage = Windows.System.UserProfile.GlobalizationPreferences.Languages[0].ToString();

            if (!(this.IsLanguageSupported(netLanguage)))
            {
                netLanguage = "en";
            }

            return new CultureInfo(netLanguage);
        }

        public void SetLocale(CultureInfo cultureInfo)
        {
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }
    }
}
