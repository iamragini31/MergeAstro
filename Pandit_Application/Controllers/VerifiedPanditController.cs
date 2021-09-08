using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class VerifiedPanditController : Controller
    {
        VerifiedPanditManager verifiedpanditmanager = new VerifiedPanditManager();
        VerifiedPanditModel verifiedpanditmodel = new VerifiedPanditModel();
        // GET: VerifiedPandit
        public ActionResult VerifiedPandit()
        {
            return View();
        }     
        public ActionResult Display()
        {
            var list = verifiedpanditmanager.Display();
            return Json(list, JsonRequestBehavior.AllowGet);
            
        }
    }
}