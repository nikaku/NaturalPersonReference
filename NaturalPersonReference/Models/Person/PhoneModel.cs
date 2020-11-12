using NaturalPersonReference.BL.Enums;
using System.ComponentModel;

namespace NaturalPersonReference.Models.Person
{
    public class PhoneModel
    {
        [DisplayName("Phone Type")]
        public PhoneType SelectedType { get; set; }
        public string PhoneNumber { get; set; }
        public int Id { get; set; }
    }
}
