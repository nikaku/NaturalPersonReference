using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.BL.Interfaces.Repositories;

namespace NaturalPersonReference.Services.Persons
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public void CreateUser(Person person)
        {
            _personRepository.Add(person);
        }
    }
}
