using NaturalPersonReference.Services.Models;
using System.Collections.Generic;

namespace NaturalPersonReference.Services.Report
{
    public interface IReportService
    {
        IEnumerable<PersonConnections> GetRelatedPersonsByConnectionType();
    }
}
