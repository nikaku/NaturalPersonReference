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
            CreateMap<PersonModel, Person>()
                .ForMember(des=>des.PicturePath, opts=>opts.MapFrom(src=>src.Picture.PicurePath))
                .ForMember(des => des.RelatedPersons, opts => opts
                  .MapFrom(src => src.SelectedPersons.Select(id =>
                   new RelatedPersons
                   {
                       RelatedPersonId = id,
                       ConnectionType = src.ConnectionType
                   }
                      )));
            CreateMap<Person, PersonModel>();
        }
    }
}
