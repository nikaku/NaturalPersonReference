using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.BL.Interfaces;
using NaturalPersonReference.BL.Interfaces.Repositories;
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

        public PersonListModel PreparePersonListModel()
        {
            var listModel = new PersonListModel();
            var persons = _unitOfWork.PersonRepository.GetAll().ToList();
            listModel.Persons = _mapper.Map<IList<PersonModel>>(persons);
            return listModel;
        }


        public void PreparePersonModel(PersonModel model, Person person)
        {
            model.Cities = _unitOfWork.CityRepository.GetAll().Select(c => new SelectListItem { Text = c.CityName, Value = c.Id.ToString() }).ToList();
        }
    }
}
