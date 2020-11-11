using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalPersonReference.Factories
{
    public interface IPhoneModelFactory
    {
        void PreparePhoneModel(PhoneModel model, Phone phone);
    }
}
