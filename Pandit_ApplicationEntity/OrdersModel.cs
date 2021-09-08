using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandit_ApplicationEntity
{
  public  class OrdersModel
    {
        public string OrderID { get; set; }
        public int ID { get; set; }
        public string Custname { get; set; }
        public string Servicename { get; set; }
        public string ReceivedDate { get; set; }

        public string Receivedtime { get; set; }
    }
}
