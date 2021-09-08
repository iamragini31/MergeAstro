using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class PunditListController : Controller
    {
        PunditListManager punditListManager = new PunditListManager();
        // GET: PunditList
        public ActionResult PunditList(string ID)
        {
            Session["SpecilizationId"] = ID;
            return View();
        }
        public ActionResult GetPunditListDetails()
        {
            long panditId = Convert.ToInt64(Session["SpecilizationId"]);
            var list = punditListManager.GetSpecialistsImagesWithName(panditId);
           
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}