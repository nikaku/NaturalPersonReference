using FluentValidation;
using NaturalPersonReference.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalPersonReference.Validators
{
    public class PhoneValidator : AbstractValidator<PhoneModel>
    {
        public PhoneValidator()
        {            
            RuleFor(p => p.PhoneNumber).MinimumLength(4).MaximumLength(50);
        }
    }
}
