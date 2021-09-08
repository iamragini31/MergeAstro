using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class DetailedReportController : Controller
    {

        DetailedReportManager detailreportmanager = new DetailedReportManager();
        // GET: DetailedReport
        public ActionResult DetailedReport()
        {

            var list = detailreportmanager.GetSpecialistsImagesWithName();
            return View(list);
        }
    }
}