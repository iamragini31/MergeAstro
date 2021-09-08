using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pandit_Application.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Email()
        {
            return View();
        }

        public ActionResult Emailforget()
        {
            return View();
        }
        public ActionResult verifiedmail()
        {
            return View();
        }
    }
}