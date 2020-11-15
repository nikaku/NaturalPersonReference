using NaturalPersonReference.BL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalPersonReference.BL.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Tin { get; set; }
        public DateTime BirthDate { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public Phone Phone { get; set; }
        public int PhoneId { get; set; }
        public string PicturePath { get; set; }
        public virtual ICollection<RelatedPersons> RelatedPersons { get; set; }
    }
}
