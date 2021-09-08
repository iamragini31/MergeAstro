using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pandit_ApplicationManager;
using Pandit_ApplicationEntity;

namespace Pandit_Application.Controllers
{
    public class ServicesController : Controller
    {
        ServicesManager servicesmanager = new ServicesManager();
        ServicesModel servicesmodel = new ServicesModel();
        // GET: Services
        public ActionResult Services()
        {
            return View();
        }

        public ActionResult GetServicesWithDetails()
        {
            var list = servicesmanager.GetServicesWithDetails();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}