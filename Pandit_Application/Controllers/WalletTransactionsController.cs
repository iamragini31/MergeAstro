using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pandit_Application.Controllers
{
    public class WalletTransactionsController : Controller
    {
        // GET: WalletTransactions
        public ActionResult WalletTransactions()
        {
            return View();
        }
    }
}