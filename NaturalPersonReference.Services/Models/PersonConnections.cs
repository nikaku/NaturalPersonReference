using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.BL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalPersonReference.Services.Models
{
    public class PersonConnections
    {
        public PersonConnections()
        {
            Connections = new Dictionary<ConnectionType, int>();
        }
        public Person person { get; set; }
        public Dictionary<ConnectionType, int> Connections { get; set; }
    }
}
