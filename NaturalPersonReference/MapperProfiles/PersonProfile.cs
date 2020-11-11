using AutoMapper;
using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalPersonReference.MapperProfiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonModel, Person>();
            CreateMap<Person, PersonModel>();
        }
    }
}
