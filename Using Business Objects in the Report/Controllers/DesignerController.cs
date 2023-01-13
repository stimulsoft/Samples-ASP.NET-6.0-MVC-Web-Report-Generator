using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using BusinessObjects;

namespace Using_Business_Objects_in_the_Report.Controllers
{
    [Route(@"{controller}/{action}")]
    public class DesignerController : Controller
    {
        static DesignerController()
        {
            // How to Activate
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult PreviewReport()
        {
            StiReport report = StiNetCoreDesigner.GetActionReportObject(this);
            report.RegBusinessObject("EmployeeIEnumerable", CreateBusinessObjectsIEnumerable.GetEmployees());
            return StiNetCoreDesigner.PreviewReportResult(this, report);
        }

        public IActionResult GetReportIEnumerableBO()
        {
            var report = new StiReport();
            report.Load(StiNetCoreHelper.MapPath(this, "Reports/BusinessObjects_IEnumerable_BO.mrt"));
            report.RegBusinessObject("EmployeeIEnumerable", CreateBusinessObjectsIEnumerable.GetEmployees());
            report.Dictionary.SynchronizeBusinessObjects(2);

            return StiNetCoreDesigner.GetReportResult(this, report);
        }

        public IActionResult DesignerEvent()
        {
            return StiNetCoreDesigner.DesignerEventResult(this);
        }
    }
}