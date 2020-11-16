using NaturalPersonReference.BL.Entities;
using System.Collections.Generic;

namespace NaturalPersonReference.BL.Interfaces.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        IEnumerable<Person> GetPersonsWithConections();
    }
}
