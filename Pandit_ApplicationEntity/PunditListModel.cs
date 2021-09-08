using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandit_ApplicationEntity
{
  public  class PunditListModel
    {
        public long specialisation_ID { get; set; }
        public string Specialization { get; set; }
        public string profile { get; set; }
        public string Fullname { get; set; }
        public double Charges_call_per_minu { get; set; }
        public double Chat_Call_per_Minu { get; set; }
        public long PanditID { get; set; }
    }
}
