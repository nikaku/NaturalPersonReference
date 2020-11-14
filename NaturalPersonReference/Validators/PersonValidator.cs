using FluentValidation;
using NaturalPersonReference.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalPersonReference.Validators
{
    public class PersonValidator : AbstractValidator<PersonModel>
    {
        public PersonValidator()
        {
            RuleFor(p => p.FirstName).MinimumLength(2).MaximumLength(50).Matches(@"^[A-Za-z]+$");
            RuleFor(p => p.LastName).MinimumLength(2).MaximumLength(50).Matches(@"^[A-Za-z]+$");
            RuleFor(p => p.Tin).Length(11).WithMessage("11 ნიშნა");
            RuleFor(p => p.BirthDate).LessThan(x => DateTime.Now.AddYears(-18)).WithMessage("პატარა ხარ");
            RuleFor(p => p.Phone.PhoneNumber).MinimumLength(4).MaximumLength(50);
        }//\p{InGeorgian}: U+10A0–U+10FF
    }
}
