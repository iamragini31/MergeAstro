using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationManager;
using Pandit_ApplicationEntity;

namespace Pandit_Application.Controllers
{
    public class GetReportController : Controller
    {
        GetReportManager getreportmanager = new GetReportManager();
        GetReportModel getreportmodel = new GetReportModel();
        // GET: GetReport
        public ActionResult GetReport(string PanditIdReport)
        {
            Session["PanditIDReport"] = PanditIdReport;
            return View();
        }
        public ActionResult GetReportsWithDetails()
        {

            var list = getreportmanager.GetReportsWithDetails();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}