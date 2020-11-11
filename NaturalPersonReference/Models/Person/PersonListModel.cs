using System.Collections.Generic;

namespace NaturalPersonReference.Models.Person
{
    public class PersonListModel
    {
        public PersonListModel()
        {
            Persons = new List<PersonModel>();
        }
        public IEnumerable<PersonModel> Persons { get; set; }
    }
}
