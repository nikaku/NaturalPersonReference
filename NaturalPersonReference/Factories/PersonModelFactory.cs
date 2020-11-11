using Microsoft.AspNetCore.Mvc.Rendering;
using NaturalPersonReference.BL.Entities;
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
        private ICityRepository _cityRepository;

        public PersonModelFactory(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public void PreparePersonModel(PersonModel model, Person person)
        {
            model.Cities = _cityRepository.GetAll().Select(c => new SelectListItem { Text = c.CityName, Value = c.Id.ToString() }).ToList();
        }
    }
}
