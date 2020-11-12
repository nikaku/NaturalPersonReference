using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.BL.Interfaces;
using NaturalPersonReference.BL.Interfaces.Repositories;

namespace NaturalPersonReference.Services.Persons
{
    public class PersonService : IPersonService
    {
        private IUnitOfWork _unitOfwork;

        public PersonService(IUnitOfWork unitOfWork)
        {
            _unitOfwork = unitOfWork;
        }
        public void CreatePerson(Person person)
        {
            _unitOfwork.PersonRepository.Add(person);
            _unitOfwork.SaveChanges();
        }

        public Person Get(int id)
        {
            return _unitOfwork.PersonRepository.Get(id);
        }
    }
}
