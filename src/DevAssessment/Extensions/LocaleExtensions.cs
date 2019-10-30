using Common.Localization;

namespace DevAssessment.Extensions
{
    public static class LocaleExtensions
    {
        public static bool IsLanguageSupported(this ILocale locale, string languageCode)
        {
            switch (languageCode)
            {
                case "en":
                case "en-US":
                    return true;
                case "fr":
                case "fr-FR":
                case "fr-US":
                    return true;
                default:
                    return false;
            }
        }
    }
}
