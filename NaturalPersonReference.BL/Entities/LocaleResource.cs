using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalPersonReference.BL.Entities
{
    public class LocaleResource
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string ResourceName { get; set; }
        public string ResourceValue { get; set; }
    }
}
