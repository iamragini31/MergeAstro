using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandit_ApplicationEntity
{
   public class OrderHistoryModel
    {
        public string Customername { get; set; }
        public string Servicename { get; set; }
        public string Serviceprice { get; set; }
        public string Received_Date { get; set; }
        public string Service_Time { get; set; }
        public string Status { get; set; }
        public double Callrate { get; set; }
        public double Duration { get; set; }
        public double Wallet { get; set; }
        public string panditName { get; set; }
        public string Orderid { get; set; }

        public long Opencall { get; set; }
        public long Openchat { get; set; }
        public long Openservice { get; set; }
        public long acceptedservice { get; set; }
        public long completedservice { get; set; }
        public long rejectedservice { get; set; }
    }
}
