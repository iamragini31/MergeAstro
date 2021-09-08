using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandit_ApplicationEntity
{
   public class CallOrdersModel
    {
        public string FirstName_Call { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Time_of_Birth { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Martial_Status { get; set; }
        public string Topicforcall { get; set; }
        public string Language { get; set; }
        public string Received_Date { get; set; }
        public string Service { get; set; }
        public int ID { get; set; }

        public string orderid { get; set; }

        public long CustID { get; set; }

        public double charges_call_per_minu { get; set; }
        public double Customerwalletamount { get; set; }

        public String Mobile { get; set; }
    }
}
