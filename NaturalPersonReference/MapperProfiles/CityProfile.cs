using AutoMapper;
using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.Models.Person;

namespace NaturalPersonReference.MapperProfiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<CityModel, City>();
        }
    }
}
