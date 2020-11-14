using NaturalPersonReference.BL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalPersonReference.Services.Persons
{
    public interface IPersonService
    {
        Person CreatePerson(Person person);
        void DeletePerson(int id);
        void UpdatePerson(Person person);
        Person Get(int id);
    }
}
