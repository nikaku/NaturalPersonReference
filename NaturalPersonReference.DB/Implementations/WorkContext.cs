using NaturalPersonReference.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalPersonReference.DB.Implementations
{
    public class WorkContext : IWorkContext
    {
        public int LanguangeId { get; set; }
    }
}
