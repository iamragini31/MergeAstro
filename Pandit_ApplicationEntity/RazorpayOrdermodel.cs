using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandit_ApplicationEntity
{
    public class RazorpayOrdermodel
    {
        public string id { get; set; }
        public string entity { get; set; }
        public long amount { get; set; }
        public long amount_paid { get; set; }
        public long amount_due { get; set; }
        public string currency { get; set; }
        public string receipt { get; set; }
        public string offer_id { get; set; }
        public string status { get; set; }
        public string balwallet { get; set; }
        public string attempts { get; set; }
        public string[] notes { get; set; }
        public long created_at { get; set; }
    }
}
