using NaturalPersonReference.BL.Entities;

namespace NaturalPersonReference.Services.localization
{
    public interface ILocalizationService
    {
        string GetResource(string resourceName);
        void InsertLocaleStringResource(LocaleResource localeResource);
    }
}
