using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandit_ApplicationEntity
{
   public class RegPanditDetailsModel
    {
        public string ID { get; set; }
        public string Fullname { get; set; }
        public string DateofBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pin { get; set; }

        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string TaxIdNumber { get; set; }
        public string YearsOfExperience { get; set; }
        public string AboutSelf { get; set; }
        public string Languages { get; set; }


        public string Bengali { get; set; }
        public string English { get; set; }
        public string urdu { get; set; }
        public string Tamil { get; set; }
        public string French { get; set; }
        public string Spanish { get; set; }
        public string German { get; set; }
        public string Hindi { get; set; }

        public byte[] ProfileImage { get; set; }
        public string profilepic { get; set; }
        public byte[] GovernmentId { get; set; }
        public string idproof { get; set; }
        public string GovernmentIdFileName { get; set; }
        public string GovernmentIdContentType { get; set; }

        public string biodata { get; set; }
        public byte[] BioData2 { get; set; }
        public string BioDataFileName { get; set; }
        public string BioDataContentType { get; set; }


        public string USerid { get; set; }
        public string Password { get; set; }

        public string Puja_Snum { get; set; }
        public string PujasName { get; set; }
        public string pujaPriceUs { get; set; }
        public string pujaPriceINR { get; set; }
        public string ServiceID { get; set; }



        public string Service_Snum { get; set; }
        public string Servicename { get; set; }
        public string ServicePriceUS { get; set; }
        public string ServicePriceINR { get; set; }


        public string Report_Snum { get; set; }
        public string ReportPriceUS { get; set; }
        public string ReportPriceINR { get; set; }
        public string ReportName { get; set; }



        public string Call_Rate_USD { get; set; }
        public string Call_Rate_INR { get; set; }
        public string Chat_Rate_USD { get; set; }
        public string Chat_Rate_INR { get; set; }


    }

}
