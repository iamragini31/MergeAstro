using Pandit_ApplicationEntity;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Pandit_ApplicationManager;
    

namespace Pandit_Application.Controllers
{
    public class AddWalletMoneyController : Controller
    {
        // GET: AddWalletMoney
        AddWalletMoneyManager manager = new AddWalletMoneyManager();
        public ActionResult AddWalletMoney(int PanditId,string Service)
        {
            Session["BackURL"] = "/CallIntakeForm/CallIntakeForm?PanditId=" + PanditId + "&Service=" + Service + "";
            var result = manager.GetServicesAmount(Service, PanditId);
            Session["Amountforpay"] = result.amount;
            Session["Productnameforpay"] = Service;
            return View();
        }


        public ActionResult PaymentForm()
        {

            System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);
            int random = rand.Next(1, 100000000);
            string Orderid = "ORDR" + random;
            string appId = "445513385d4f0d990b78093be15544";
            string secretKey = "0321cd0e179b83f48d1c6fbc457905583b7dd413";
            //string orderId = "order_0011";
            string orderAmount = "10";
            string orderCurrency = "INR";
            string customerEmail = "iamragini23@gmail.com";
            string customerName = "Ratini";
            string customerPhone = "8789635170";
            string returnUrl = "http://localhost:58347/Cashfree/Index";
            var postdata = "appId=" + appId + "&secretKey=" + secretKey + "&orderId=" + Orderid + "&orderAmount=" + orderAmount + "&orderCurrency=" + orderCurrency + "&customerEmail=" +
            "" + customerEmail + "&customerName=" + customerName + "&customerPhone=" + customerPhone + "&returnUrl=" + returnUrl + "";



            string URL = "https://test.cashfree.com/api/v1/order/create";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            request.ContentLength = postdata.Length;
            request.ContentType = "application/x-www-form-urlencoded";

            using (Stream writeStream = request.GetRequestStream())
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(postdata);
                writeStream.Write(byteArray, 0, byteArray.Length);
                writeStream.Close();
            }

            string result = string.Empty;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        result = readStream.ReadToEnd();
                    }

                }
            }
            var ResponseModel = new JavaScriptSerializer().Deserialize<AddWalletMoneyModel>(result);

            var paymentLink = ResponseModel.paymentLink;
            return Json(paymentLink, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RazorpayGenerateOrderid(double amount, string balance)
        {
            System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);
            int random = rand.Next(1, 100000000);
            string Orderid = "ORDR" + random;
            string key = "rzp_live_Ks5ay3Dx0yIaEi";
            string secret = "4p1tLojNqQ0nVwe96i4ETeH6";
            Session["amount1"] = amount;
            Session["gstamtC_C"] = 0.18 * amount;
            amount = ((0.18* amount)+ amount) * 100;
            //amount = 1 * 100;
            RazorpayClient client = new RazorpayClient(key, secret);
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", amount); // amount in the smallest currency unit
            options.Add("receipt", Orderid);
            options.Add("currency", "INR");
            options.Add("payment_capture", 1);
            System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            Order order = client.Order.Create(options);

            string orderid = order["id"];

            //List<RazorpayOrdermodel> list = JsonConvert.DeserializeObject<List<RazorpayOrdermodel>>(orderid);
            RazorpayOrdermodel model = new RazorpayOrdermodel();
            model.id = orderid;
            var rechargeamount = amount / 100;
            Session["amount"] = rechargeamount;
            var gstcall_chat=  Session["gstamt"] = 0.18 * rechargeamount;
            var rechargegst = 0.18 * rechargeamount;
            Session["gstrecharge"] = rechargegst;
            var rechargetotal = rechargeamount + rechargegst;
            Session["rechargetotal"] = rechargeamount;


            string balwallet = balance;
            Session["balwallet"] = balwallet;
            Session["PaymentOrderid"] = model.id;
            var amot = amount / 100;
            Session["PaymentAmount"] = amot;
            //var pay=orderid.Payments;
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPaymentid(string PaymentID, string OrderID)
        {
            var res = manager.SaveTransaction(PaymentID, Convert.ToInt64(Session["PaymentAmount"]), Convert.ToInt64(Session["CustomerID"]), OrderID);
            return Json(res,JsonRequestBehavior.AllowGet);
        }
    }
}