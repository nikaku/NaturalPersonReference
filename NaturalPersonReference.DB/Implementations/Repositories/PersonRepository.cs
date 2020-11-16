using Microsoft.EntityFrameworkCore;
using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.BL.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace NaturalPersonReference.DB.Implementations.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DataContext context) : base(context)
        {
        }

        public new Person Get(int id)
        {
            return PersonContext.Persons.Include(c => c.City).Include(p => p.Phone).Include(x=>x.RelatedPersons).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Person> GetPersonsWithConections()
        {
            return PersonContext.Persons.Include(x => x.RelatedPersons);
        }

        private DataContext PersonContext => Context as DataContext;
    }
}
