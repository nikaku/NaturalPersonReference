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
        public Phone Phone { get; set; }
        public string PicturePath { get; set; }
        public virtual ICollection<RelatedPersons> RelatedTo { get; set; }
        public virtual ICollection<RelatedPersons> RelatedFrom { get; set; }
    }
}
