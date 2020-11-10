using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalPersonReference.BL.Entities
{
    public class RelatedPersons
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public Person Person { get; set; }
        public Person RelatedPerson { get; set; }
    }
}
