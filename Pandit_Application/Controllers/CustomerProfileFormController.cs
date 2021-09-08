using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pandit_Application.Controllers
{
    public class CustomerProfileFormController : Controller
    {
        // GET: CustomerProfileForm
        public ActionResult CustomerProfileForm()
        {
            return View();
        }   
        public ActionResult SavedChanges()
        {
            return View();
        }
    }
}