using System.Globalization;

namespace Common.Localization
{
    public interface ILocale
    {
        CultureInfo GetCurrentCultureInfo();

        void SetLocale(CultureInfo cultureInfo);
    }
}
