using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class SpecialistsController : Controller
    {
        SpecialistsManager specialistmanager = new SpecialistsManager();
        SpecialistsModel specialistmodel = new SpecialistsModel();
        // GET: Specialists
        public ActionResult Specialists()
        {
           return View();
        }

        public ActionResult GetSkill()
        {
            var list = specialistmanager.GetAllSpecialization();
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public ActionResult getAllPuja()
        {
            var list = specialistmanager.GetAllPuja();
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetSpecialistsImagesWithName()
        {
            var list = specialistmanager.GetSpecialistsImagesWithName();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}