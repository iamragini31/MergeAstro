using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class PackagesController : Controller
    {
        PackagesManager packagesmanager = new PackagesManager();
        PackagesModel packagesmodel = new PackagesModel();
        // GET: Packages
        public ActionResult Packages()
        {
            if ((Session["PanditID"]).ToString() == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View();
            }
        }



        public ActionResult BindPackages()
        {
            var list = packagesmanager.Bindpackages(Convert.ToInt32(Session["PanditID"]));
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BindPackagesForUpgrade()
        {
            var list = packagesmanager.BindPackagesForUpgrade();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}