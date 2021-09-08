using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandit_ApplicationEntity
{
  public  class TalktoSpecialistModel
    {

        public long PanditId { get; set; }
        public string PanditName { get; set; }
        public string DisplayName { get; set; }
        public Byte[] Image { get; set; }
        public double callcharge { get; set; }
        public double chatcharge { get; set; }
        public string experience { get; set; }
        public string Specialisation { get; set; }
        public string listSpecialisation { get; set; }
    }
}
