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
        void DeleteRelatedPerson(int id, IEnumerable<int> ids);
        void UpdatePerson(Person person);
        Person Get(int id);
        IEnumerable<Person> GetAll();
        IEnumerable<Person> GetAllWithConnections();        
    }
}
