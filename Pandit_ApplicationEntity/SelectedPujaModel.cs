using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandit_ApplicationEntity
{
   public class SelectedPujaModel
    {
        public string name { get; set; }
        public string Countrycode { get; set; }
        public string day { get; set; }
        public long Mobile { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }

        public string TimeOfBirth { get; set; }
        public string CityOfBirth { get; set; }
        public string CountryofBirth { get; set; }
        public string StateofBirth { get; set; }

        public string Occupation { get; set; }
        public string TopicforCall { get; set; }
        public string PreferredLang { get; set; }
        public string CountryCode { get; set; }
        public long CustomerID { get; set; }
        public string Martial_Status { get; set; }
        public string Comment { get; set; }
        public string Servicename { get; set; }
        public long ServiceID { get; set; }

        // further Addition

        public string Address { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Country { get; set; }
        public String Zip { get; set; }
        public string Addressid { get; set; }
        public string completeaddress { get; set; }
        public long PanditID { get; set; }
        public long amount { get; set; }
    }
}
