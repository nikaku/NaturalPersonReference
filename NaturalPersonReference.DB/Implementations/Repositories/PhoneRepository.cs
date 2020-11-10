using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.BL.Interfaces.Repositories;

namespace NaturalPersonReference.DB.Implementations.Repositories
{
    public class PhoneRepository : Repository<Phone>, IPhoneRepository
    {
        public PhoneRepository(DataContext context) : base(context)
        {
        }

        public DataContext PhoneContext => Context as DataContext;
    }
}
