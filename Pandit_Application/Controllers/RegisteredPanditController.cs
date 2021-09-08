using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class RegisteredPanditController : Controller
    {
        RegisteredPanditManager registeredPanditmanger = new RegisteredPanditManager();
        RegisteredPanditModel registeredpanditmodel = new RegisteredPanditModel();

        // GET: RegisteredPandit
        public ActionResult RegisteredPandit()
        {
            return View();
        }

        public ActionResult Display()
        {
            var list = registeredPanditmanger.Display();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}