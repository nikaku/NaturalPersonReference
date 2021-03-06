﻿using AutoMapper;
using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.Models.Person;

namespace NaturalPersonReference.MapperProfiles
{
    public class PhoneProfile : Profile
    {
        public PhoneProfile()
        {
            CreateMap<PhoneModel, Phone>().ForMember(des=>des.Type, opt=>opt.MapFrom(src=>src.SelectedType));
            CreateMap<Phone, PhoneModel>().ForMember(des => des.SelectedType, opt => opt.MapFrom(src => src.Type));
        }
    }
}
