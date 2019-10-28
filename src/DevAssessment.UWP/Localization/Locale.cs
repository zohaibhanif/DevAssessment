using Common.Localization;
using System.Globalization;

namespace DevAssessment.UWP.Localization
{
    public class Locale : ILocale
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            return new CultureInfo(
                Windows.System.UserProfile.GlobalizationPreferences.Languages[0].ToString());
        }

        public void SetLocale(CultureInfo cultureInfo)
        {
        }
    }
}
