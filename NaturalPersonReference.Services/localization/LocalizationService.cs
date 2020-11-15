using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalPersonReference.Services.localization
{
    public class LocalizationService : ILocalizationService
    {
        private IUnitOfWork _unitOfwork;
        public LocalizationService(IUnitOfWork unitOfWork)
        {
            _unitOfwork = unitOfWork;
        }
        public string GetResource(string resourceName, int languageId)
        {
            var resource = _unitOfwork.LocaleResourceRepository.Find(x => x.ResourceName == resourceName && x.LanguageId == languageId);
            return resource == null ? resourceName : resource.ResourceValue;
        }

        public void InsertLocaleStringResource(LocaleResource localeResource)
        {
            throw new NotImplementedException();
        }
    }
}
