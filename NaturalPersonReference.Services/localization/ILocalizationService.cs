using NaturalPersonReference.BL.Entities;

namespace NaturalPersonReference.Services.localization
{
    public interface ILocalizationService
    {
        string GetResource(string resourceName, int languageId);
        void InsertLocaleStringResource(LocaleResource localeResource);
    }
}
