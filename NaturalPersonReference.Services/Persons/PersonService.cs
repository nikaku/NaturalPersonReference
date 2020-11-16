using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NaturalPersonReference.Services.Persons
{
    public class PersonService : IPersonService
    {
        private IUnitOfWork _unitOfwork;

        public PersonService(IUnitOfWork unitOfWork)
        {
            _unitOfwork = unitOfWork;
        }
        public Person CreatePerson(Person person)
        {
            var personAdded = _unitOfwork.PersonRepository.Add(person);
            _unitOfwork.SaveChanges();
            return personAdded;
        }

        public void DeletePerson(int id)
        {
            var prerson = _unitOfwork.PersonRepository.Get(id);
            if (prerson != null)
            {
                foreach (var relatedPerson in prerson.RelatedPersons)
                {
                    _unitOfwork.RelatedPersonsRepository.Remove(relatedPerson);
                }

                _unitOfwork.PersonRepository.Remove(prerson);
                _unitOfwork.SaveChanges();
            }
        }

        public void DeleteRelatedPerson(int id, IEnumerable<int> ids)
        {
            var relatedPrerson = _unitOfwork.RelatedPersonsRepository.FindAll(x => ids.Contains(x.RelatedPersonId));

            foreach (var relatedPerson in relatedPrerson)
            {
                _unitOfwork.RelatedPersonsRepository.Remove(relatedPerson);
            }

            _unitOfwork.SaveChanges();
        }

        public Person Get(int id)
        {
            return _unitOfwork.PersonRepository.Get(id);
        }

        public IEnumerable<Person> GetAll()
        {
            return _unitOfwork.PersonRepository.GetAll();
        }

        public void UpdatePerson(Person person)
        {
            var personInDb = _unitOfwork.PersonRepository.Get(person.Id);

            if (personInDb == null)
            {
                throw new Exception("User Not Fond");
            }

            var phoneInDb = _unitOfwork.PhoneRepository.Get(person.PhoneId);

            if (phoneInDb != null)
            {
                phoneInDb.PhoneNumber = person.Phone.PhoneNumber;
                phoneInDb.Type = person.Phone.Type;
                _unitOfwork.PhoneRepository.Update(phoneInDb);
            }

            personInDb.FirstName = person.FirstName;
            personInDb.LastName = person.LastName;
            personInDb.BirthDate = person.BirthDate;
            personInDb.Gender = person.Gender;
            personInDb.Tin = person.Tin;
            personInDb.PhoneId = person.PhoneId;
            personInDb.CityId = person.CityId;

            _unitOfwork.PersonRepository.Update(personInDb);
            _unitOfwork.SaveChanges();
        }
    }
}
