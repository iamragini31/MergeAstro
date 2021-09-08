using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class NewlyRegisteredPanditController : Controller
    {
        NewlyRegisteredPanditManager newlyregisteredpanditmanager = new NewlyRegisteredPanditManager();
        NewlyRegisteredPanditModel newlyregisteredpanditmodel = new NewlyRegisteredPanditModel();
        // GET: c
        public ActionResult NewlyRegisteredPandit()
        {
            //List<NewlyRegisteredPanditModel> ListNewlyRegisteredPandit = new List<NewlyRegisteredPanditModel>();
            //ListNewlyRegisteredPandit = newlyregisteredpanditmanager.Display();
            //if (ListNewlyRegisteredPandit.Count > 0)
            //{
            //    newlyregisteredpanditmodel.PanditID = ListNewlyRegisteredPandit[0].PanditID;
            //    newlyregisteredpanditmodel.Fullname = ListNewlyRegisteredPandit[0].Fullname;


            //}


            return View();
        }
        public ActionResult AdminNewApplicant()
        {
            //List<NewlyRegisteredPanditModel> ListNewlyRegisteredPandit = new List<NewlyRegisteredPanditModel>();
            //ListNewlyRegisteredPandit = newlyregisteredpanditmanager.Display();
            //if (ListNewlyRegisteredPandit.Count > 0)
            //{
            //    newlyregisteredpanditmodel.PanditID = ListNewlyRegisteredPandit[0].PanditID;
            //    newlyregisteredpanditmodel.Fullname = ListNewlyRegisteredPandit[0].Fullname;


            //}


            return View();
        }
        public ActionResult Display()
        {

            var list = newlyregisteredpanditmanager.Display();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}