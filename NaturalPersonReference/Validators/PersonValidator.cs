using FluentValidation;
using NaturalPersonReference.Models.Person;
using NaturalPersonReference.Services.localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalPersonReference.Validators
{
    public class PersonValidator : AbstractValidator<PersonModel>
    {
        public PersonValidator(ILocalizationService localizationService)
        {
            RuleFor(p => p.FirstName).NotEmpty().MinimumLength(2).MaximumLength(50).Matches(@"(^[\u10A0-\u10FF]+$)|(^[A-Za-z]+$)").WithMessage(localizationService.GetResource("FirstName.Error"));
            RuleFor(p => p.LastName).NotEmpty().MinimumLength(2).MaximumLength(50).Matches(@"^(^[\u10A0-\u10FF]+$)|(^[A-Za-z]+$)").WithMessage(localizationService.GetResource("LastName.Error"));
            RuleFor(p => p.Tin).Length(11).WithMessage(localizationService.GetResource("Tin.Error"));
            RuleFor(p => p.BirthDate).LessThan(x => DateTime.Now.AddYears(-18)).WithMessage(localizationService.GetResource("LastName.BirthDate"));
        }
    }
}
