using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;
namespace Pandit_Application.Controllers
{
    public class ChangePasswordController : Controller
    {
        // GET: ChangePassword
        ProfilePageManager manager = new ProfilePageManager();
        public ActionResult ChangePassword()
        {
            return View();
        }

      
        public ActionResult changepass(string oldpass,string txtnewpass,string txtconfirmpass)
        {
            var custid = Session["CustomerID"].ToString();
           
               var res= manager.Changepassword(oldpass,txtnewpass,txtconfirmpass, custid);
                return Json(res,JsonRequestBehavior.AllowGet);
            

        }
    }
}