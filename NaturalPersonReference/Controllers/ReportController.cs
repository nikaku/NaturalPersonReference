using Microsoft.AspNetCore.Mvc;
using NaturalPersonReference.Services.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalPersonReference.Controllers
{
    public class ReportController : Controller
    {
        private IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        public ActionResult Connections()
        {
            var report = _reportService.GerRelatedPersonsByConnectionType();
            return View(report);
        }
    }
}
