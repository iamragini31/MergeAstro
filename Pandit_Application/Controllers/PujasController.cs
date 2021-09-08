using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationManager;
using Pandit_ApplicationEntity;

namespace Pandit_Application.Controllers
{
    public class PujasController : Controller
    {
        PujasManager pujasmanager = new PujasManager();
        PujasModel pujasmodel = new PujasModel();

        // GET: Pujas
        public ActionResult Pujas()
        {
            return View();
        }

        public ActionResult GetPujasWithDetails()
        {
            var list = pujasmanager.GetPujasWithDetails();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}