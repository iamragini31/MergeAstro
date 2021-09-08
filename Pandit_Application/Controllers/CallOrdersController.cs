using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pandit_Application.Models;
using Pandit_ApplicationEntity;
using Pandit_ApplicationManager;

namespace Pandit_Application.Controllers
{
    public class CallOrdersController : Controller
    {
        CallOrdersManager callordersmanager = new CallOrdersManager();
        CallOrdersModel callordersmodel = new CallOrdersModel();
        // GET: CallOrders
        public ActionResult CallOrders()
        {
            return View();
        }

        public ActionResult BindCalls()
        {

            var res = callordersmanager.BindCalls(Session["PanditID"].ToString());
            return Json(res, JsonRequestBehavior.AllowGet);


        }



        public ActionResult CreateRoom()
        {
            #region
            RoomBodySip roomBodySip = new RoomBodySip();
            roomBodySip.enabled = false;
            RoomBodySettings roomBodySettings = new RoomBodySettings();
            roomBodySettings.scheduled = false;
            roomBodySettings.adhoc = true;
            roomBodySettings.moderators = "1";
            roomBodySettings.participants = "1";
            roomBodySettings.duration = "10";
            roomBodySettings.quality = "SD";
            roomBodySettings.auto_recording = false;
            var rand = new Random();
            int randNum = rand.Next();
            RoomBody roomBody = new RoomBody();
            roomBody.name = $"Sample Room {randNum}";
            roomBody.owner_ref = $"{randNum}";
            roomBody.settings = roomBodySettings;
            roomBody.sip = roomBodySip;
            #endregion
            var json = JsonConvert.SerializeObject(roomBody);
            var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{ConfigurationManager.AppSettings["APP_ID"]}:{ConfigurationManager.AppSettings["APP_KEY"]}"));
            string JsonResult = string.Empty;
            try
            {
                var t = Task.Run(() => PostRequestCreateRoom(json, authToken));
                t.Wait();
                JsonResult = t.Result;
                //SqlParameter p2 = new SqlParameter("@LogDetails", JsonResult);
                //int res1 = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "sp_Log", p2);
                System.Web.Script.Serialization.JavaScriptSerializer jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                dynamic stuff = JObject.Parse(JsonResult);
                string roomid = stuff.room.room_id;

                return Json(roomid, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //SqlParameter p2 = new SqlParameter("@LogDetails", ex.ToString());
                //int res1 = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "sp_Log", p2);
                Console.WriteLine(JsonResult);
                return Json(JsonResult, JsonRequestBehavior.AllowGet);
            }
        }



        private static async Task<string> PostRequestCreateRoom(string json, string authToken)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                var client = new HttpClient(handler);

                client.BaseAddress = new Uri("https://servertestastrolozee.com/");
                //var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);
                string apiEndpoint = $"{ConfigurationManager.AppSettings["API_URL"]}rooms/";

                //SqlParameter p1 = new SqlParameter("@LogDetails", apiEndpoint);
                //int res = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "sp_Log", p1);

                var data = new StringContent(json, Encoding.UTF8, "application/json");
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                       | SecurityProtocolType.Tls11
                       | SecurityProtocolType.Tls12
                       | SecurityProtocolType.Ssl3;

                var response = await client.PostAsync(apiEndpoint, data);
                //SqlParameter p2 = new SqlParameter("@LogDetails", response.Content.ReadAsStringAsync().Result);
                //int res1 = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "sp_Log", p2);
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                //SqlParameter p2 = new SqlParameter("@LogDetails", ex.ToString());
                //int res1 = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "sp_Log", p2);
                throw ex;
            }

        }

        public ActionResult GetRoom(string roomId, long CustID, double charges_call_per_minu,double Customerwalletamount,long Bookingid,string Mobile)
        {
            Session["CustIDforcall"] = CustID;
            Session["charges_call_per_minu"] = charges_call_per_minu;
            Session["Customerwalletamount"] = Customerwalletamount;
            Session["Bookingid"] = Bookingid;
            Session["Mobile"] = Mobile;
            var t = Task.Run(() => GetReqRoom(roomId));
            t.Wait();
            string JsonResult = t.Result;

            return Json(JsonResult, JsonRequestBehavior.AllowGet);
        }
        public async Task<string> GetReqRoom(string roomId)
        {
            //("/api/get-room/{roomId}")
            // build auth token for using EnableX video API
            var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{ConfigurationManager.AppSettings["APP_ID"]}:{ConfigurationManager.AppSettings["APP_KEY"]}"));

            HttpClientHandler handler = new HttpClientHandler();
            var client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://servertestastrolozee.com/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);

            // EnableX get room details api - /api/rooms/{roomId}
            string apiEndpoint = $"{ConfigurationManager.AppSettings["API_URL"]}rooms/{roomId}";

            var result = await client.GetAsync(apiEndpoint);
            return await result.Content.ReadAsStringAsync();
        }

        public ActionResult CreateToken(string details)
        {
            var t = Task.Run(() => PostCreateToken(details));
            t.Wait();
            string JsonResult = t.Result;

            return Json(JsonResult, JsonRequestBehavior.AllowGet);
        }
        public async Task<string> PostCreateToken(string details)
        {

            CreateTokenBody createTokenBody = JsonConvert.DeserializeObject<CreateTokenBody>(details);
            string requestJSON = "";

            if (createTokenBody.roomId != "")
            {

                var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{ConfigurationManager.AppSettings["APP_ID"]}:{ConfigurationManager.AppSettings["APP_KEY"]}"));

                HttpClientHandler handler = new HttpClientHandler();
                var client = new HttpClient(handler);
                client.BaseAddress = new Uri("https://servertestastrolozee.com/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);


                string apiEndpoint = $"{ConfigurationManager.AppSettings["API_URL"]}rooms/{createTokenBody.roomId}/tokens";

                var data = new StringContent(details, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(apiEndpoint, data);

                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return "";
            }
        }
    }
}