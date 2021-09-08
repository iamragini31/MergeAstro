using DataAccessLayer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pandit_Application.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class CallCustomerController : Controller
    {
        // GET: CallCustomer
        CallCustomerManager manager = new CallCustomerManager();
        public ActionResult CallCustomer(string token)
        {
            return View();
        }

        public ActionResult Deductedamount(double moneydeducted)
        {

            double custid = Convert.ToDouble(Session["CustIDforcall"]);
            var res = manager.Deductedamount(Convert.ToDouble(moneydeducted), custid,
                                             Convert.ToDouble(Session["Bookingid"]));
            return Json( res,JsonRequestBehavior.AllowGet);
        }


    }
}