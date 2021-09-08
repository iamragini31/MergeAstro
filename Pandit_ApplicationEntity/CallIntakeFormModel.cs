using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandit_ApplicationEntity
{
  public  class CallIntakeFormModel
    {
        public string name { get; set; }
        public string gender { get; set; }
        public string Martial_Status { get; set; }
        public string DOB { get; set; }
     
        public string CountryCode { get; set; }
        public long Mobile { get; set; }
       
        public string Email { get; set; }
        public string PreferredLang { get; set; }
       
        public string TopicforCall { get; set; }
        public long CustomerID { get; set; }
        public string Service { get; set; }

        public string TimeOfBirth { get; set; }
        public string CityOfBirth { get; set; }
        public string CountryofBirth { get; set; }
        public string StateofBirth { get; set; }

        public string Country { get; set; }
        public string State { get; set; }
        // further Addition
        public string City { get; set; }
        public string Zip { get; set; }
        public string Address { get; set; }
        public string Occupation { get; set; }
        public string Addressid { get; set; }
        public string completeaddress { get; set; }
    }
}
