using Microsoft.EntityFrameworkCore;
using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.BL.Interfaces.Repositories;
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

        private DataContext PersonContext => Context as DataContext;
    }
}
