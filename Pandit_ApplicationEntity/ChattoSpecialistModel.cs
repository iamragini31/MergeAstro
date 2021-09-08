using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandit_ApplicationEntity
{
   public class ChattoSpecialistModel
    {


        public byte[] Image { get; set; }
        public string Panditname { get; set; }
        public string DisplayName { get; set; }
        public string experience { get; set; }
        public string Language { get; set; }
        public double chatcharge { get; set; }
        public long Panditid { get; set; }
        public double callcharge { get; set; }
        public string Specilization { get; set; }
        public string ListSpecilisation { get; set; }
        public string type { get; set; }
    }
}
