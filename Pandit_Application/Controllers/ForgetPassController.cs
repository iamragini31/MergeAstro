using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pandit_Application.Controllers
{
    public class ForgetPassController : Controller
    {
        // GET: ForgetPass
        public ActionResult ForgetPass()
        {
            return View();
        }   
        public ActionResult CustomerForgetPass()
        {
            return View();
        }
    }
}