using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.BL.Enums;
using NaturalPersonReference.BL.Interfaces;
using NaturalPersonReference.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaturalPersonReference.Services.Report
{
    public class ReportService : IReportService
    {
        private IUnitOfWork _unitOfwork;

        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfwork = unitOfWork;
        }

        public IEnumerable<PersonConnections> GetRelatedPersonsByConnectionType()
        {
            IList<PersonConnections> personConnections = new List<PersonConnections>();
            var persons = _unitOfwork.PersonRepository.GetPersonsWithConections();

            foreach (var person in persons)
            {
                var personConnectionsCount = new Dictionary<ConnectionType, int>();

                foreach (ConnectionType type in Enum.GetValues(typeof(ConnectionType)))
                {
                    var count = person.RelatedPersons.Where(x => x.ConnectionType == type).Count();
                    personConnectionsCount.Add(type, count);
                }

                personConnections.Add(new PersonConnections { person = person, Connections = personConnectionsCount });
            }

            return personConnections;
        }
    }
}
