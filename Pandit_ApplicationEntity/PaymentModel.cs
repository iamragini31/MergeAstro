using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandit_ApplicationEntity
{
   public class PaymentModel
    {
        public string FullName { get; set; }
        public long PanditId { get; set; }
        public string PanditId1 { get; set; }

        public long Bookingid { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string duration { get; set; }
        public long Callchatrate { get; set; }
        public string receiveddate { get; set; }
        public long amount { get; set; }
        public string customername { get; set; }
        public string Servicename { get; set; }

    }
}
