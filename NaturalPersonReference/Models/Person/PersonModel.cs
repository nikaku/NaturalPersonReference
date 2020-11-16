using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.BL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        public CityModel City { get; set; }
        public int CityId { get; set; }
        public IList<SelectListItem> Cities { get; set; }
        public IList<SelectListItem> RelatedPersons { get; set; }
        public IList<int> SelectedPersons { get; set; }
        public ConnectionType ConnectionType { get; set; }
        public PhoneModel Phone { get; set; }
        public int PhoneId { get; set; }
        public PictureModel Picture { get; set; }
    }
}
