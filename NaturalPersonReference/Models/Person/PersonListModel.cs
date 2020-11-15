using NaturalPersonReference.Models.Paging;
using System;
using System.Collections.Generic;

namespace NaturalPersonReference.Models.Person
{
    public class PersonListModel
    {
        public PaginatedList<PersonModel> Persons { get; set; }
    }
}
