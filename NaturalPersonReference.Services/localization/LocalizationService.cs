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
        private readonly IWorkContext _workContext;

        public LocalizationService(IUnitOfWork unitOfWork, IWorkContext workContext)
        {
            _unitOfwork = unitOfWork;
            _workContext = workContext;
        }
        public string GetResource(string resourceName)
        {
            var resource = _unitOfwork.LocaleResourceRepository.Find(x => x.ResourceName == resourceName && x.LanguageId == _workContext.LanguangeId);
            return resource == null ? resourceName : resource.ResourceValue;
        }

        public void InsertLocaleStringResource(LocaleResource localeResource)
        {
            _unitOfwork.LocaleResourceRepository.Add(localeResource);
            _unitOfwork.SaveChanges();
        }
    }
}
