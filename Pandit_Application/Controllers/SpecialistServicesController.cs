using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class SpecialistServicesController : Controller
    {
        SpecialistServicesManager manager = new SpecialistServicesManager();

        // GET: SpecialistServices
        public ActionResult SpecialistServices(int ID,string Type,string PartnerFlag, string Name)
        {

            Session["PartnerFlag"] = PartnerFlag;
            Session["lblPujaName"] = Name;

            var list = manager.GetSpecialistsImagesWithName(ID,Type);
                return View(list);
          
           
        }
    }
}