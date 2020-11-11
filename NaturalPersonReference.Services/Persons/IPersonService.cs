using NaturalPersonReference.BL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalPersonReference.Services.Persons
{
    public interface IPersonService
    {
        void CreatePerson(Person person);
    }
}
