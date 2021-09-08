using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandit_ApplicationEntity
{
    public class ServicesMasterModel
    {
        public string Snum { get; set; }
        public string ServiceName { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string ChangeStatus { get; set; }

        public long ID { get; set; }
        //public byte[] ServiceImage { get; set; }
        public string ServiceImage { get; set; }
        public string ServiceImagePath { get; set; }
        public string ServiceImagecontent { get; set; }
    }
}
