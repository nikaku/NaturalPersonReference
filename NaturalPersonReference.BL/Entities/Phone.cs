using NaturalPersonReference.BL.Enums;

namespace NaturalPersonReference.BL.Entities
{
    public class Phone
    {
        public int Id { get; set; }
        public PhoneType Type { get; set; }
        public string PhoneNumber { get; set; }
    }
}
