using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.BL.Interfaces;
using NaturalPersonReference.BL.Interfaces.Repositories;
using NaturalPersonReference.Models.Paging;
using NaturalPersonReference.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalPersonReference.Factories
{
    public class PersonModelFactory : IPersonModelFactory
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public PersonModelFactory(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public PersonListModel PreparePersonListModel(int pageNumber, string searchString)
        {
            var listModel = new PersonListModel();
            var persons = _mapper.Map<IList<PersonModel>>(_unitOfWork.PersonRepository.FindAll(
                x =>
                (x.FirstName.Contains(searchString)) || (string.IsNullOrWhiteSpace(searchString))
            ));
            listModel.Persons = PaginatedList<PersonModel>.CreateAsync(persons, pageNumber, 5).Result; //TODO Move PageSize To Conig        
            return listModel;
        }

        public PersonModel PreparePersonModel(Person person)
        {
            PersonModel model = new PersonModel();

            if (person != null)
            {
                model.FirstName = person.FirstName;
                model.LastName = person.LastName;
                model.Gender = person.Gender;
                model.Tin = person.Tin;
                model.BirthDate = person.BirthDate;
                model.City = _mapper.Map<CityModel>(person.City);
                model.Phone = _mapper.Map<PhoneModel>(person.Phone);
                model.PhoneId = person.PhoneId;
                model.CityId = person.CityId;
            }

            model.Cities = _unitOfWork.CityRepository.GetAll().Select(c => new SelectListItem { Text = c.CityName, Value = c.Id.ToString() }).ToList();

            model.RelatedPersons = _unitOfWork.PersonRepository.GetAll().Select(c => new SelectListItem { Text = $"{ c.FirstName} {c.LastName} ", Value = c.Id.ToString() }).ToList();

            return model;
        }
    }
}
