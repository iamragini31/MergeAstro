using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandit_ApplicationEntity
{
  public  class PujaModelMaster
    {
        public string Snum { get; set; }
        public string PujaName { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string ChangeStatus { get; set; }

        public byte[] PujaImage { get; set; }
        public string PujaFileName { get; set; }
        public string PujaContentType { get; set; }
        public long ID { get; set; }

        public string Snum1 { get; set; }
        public string Pujasname1 { get; set; }
        public string Price1 { get; set; }
        public string Description1 { get; set; }
    }
}
