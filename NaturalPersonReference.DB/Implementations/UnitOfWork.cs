using NaturalPersonReference.BL.Interfaces;
using NaturalPersonReference.BL.Interfaces.Repositories;
using NaturalPersonReference.DB.Implementations.Repositories;
using System;

namespace NaturalPersonReference.DB
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DataContext _dataContext;
        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
            PersonRepository = new PersonRepository(dataContext);
            CityRepository = new CityRepository(dataContext);
            PhoneRepository = new PhoneRepository(dataContext);
        }

        public IPersonRepository PersonRepository { get; }

        public ICityRepository CityRepository { get; }

        public IPhoneRepository PhoneRepository { get; }

        public void Dispose()
        {
            _dataContext.Dispose();
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }
    }
}