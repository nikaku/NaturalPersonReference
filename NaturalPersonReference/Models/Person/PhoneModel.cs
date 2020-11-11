using NaturalPersonReference.BL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalPersonReference.Models.Person
{
    public class PhoneModel
    {
        [DisplayName("Phone Type")]
        public PhoneType SelectedType { get; set; }
        public string PhoneNumber { get; set; }
    }
}
