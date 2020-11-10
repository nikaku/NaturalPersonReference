using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.BL.Interfaces.Repositories;

namespace NaturalPersonReference.DB.Implementations.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DataContext context) : base(context)
        {
        }
        private DataContext PersonContext => Context as DataContext;
    }
}
