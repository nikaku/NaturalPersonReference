using Microsoft.AspNetCore.Mvc.Rendering;
using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.BL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalPersonReference.Models.Person
{
    public class PersonModel
    {
        public PersonModel()
        {
            Cities = new List<SelectListItem>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Tin { get; set; }
        public DateTime BirthDate { get; set; }
        public CityModel City { get; set; }
        public IList<SelectListItem> Cities { get; set; }
        public Phone PhoneNumber { get; set; }
        public string PicturePath { get; set; }
    }
}
