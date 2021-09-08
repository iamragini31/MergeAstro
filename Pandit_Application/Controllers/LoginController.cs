using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationManager;
using Pandit_ApplicationEntity;


namespace Pandit_Application.Controllers
{
    public class LoginController : Controller
    {
        LoginManager loginmanger = new LoginManager();
        LoginModel loginmodel = new LoginModel();
        // GET: Login
        public ActionResult Login()
        {
            //List<LoginModel> listLoginModel = new List<LoginModel>();
            //listLoginModel = loginmanger.LoginReDirect();
            //if (listLoginModel.Count > 0)
            //{
            //    Session["PanditID"] = listLoginModel[0].ID;

            //    string Status = listLoginModel[0].Status;

            //    if (Status == "1" )
            //    {
            //        return RedirectToAction("RegisterForm", "RegisterForm");
            //    }
            //    else if(Status == "2")
            //    {
            //        return RedirectToAction("Default", "Default");
            //    }
            //    else
            //    {
            //        return RedirectToAction("Login", "Login");
            //    }

            //}
            //else
            //{
            //    return View();
            //}
            return View();

        }

        public ActionResult LoginUser(string Username, string password)
        {
            string Status = "";
            var res = loginmanger.LoginReDirect(Username, password);
            if (res.Count > 0)
            {
                Session["PanditID"] = res[0].ID;
                Session["UserName"] = res[0].UserName;
                Status = res[0].Status;

                //if (Status == "1")
                //{
                //    return RedirectToAction("RegisterForm", "RegisterForm");
                //}
                //else if (Status == "2")
                //{
                //    return RedirectToAction("Default", "Default");
                //}
                //else
                //{
                //    return RedirectToAction("Login", "Login");
                //}

            }
            return Json(Status, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}