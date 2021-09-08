using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandit_ApplicationEntity
{
    public class RegisterForm2Model
    {
        public string BankTransfer { get; set; }
        public string BankName { get; set; }
        public long AccNumber { get; set; }
        public string AccHolderName { get; set; }
        public string IFSCCode { get; set; }
        public string RoutingNum { get; set; }
        public string Email_Bank { get; set; }



        public string ZelleTransfer { get; set; }
        public long PhoneNumberZelle { get; set; }
        public string EmailZelle { get; set; }


        public string PaypalTransfer { get; set; }
        public string PaypalAccountNumber { get; set; }
        public string Email_Paypal { get; set; }


        public string GooglePayTransfer { get; set; }
        public string GooglePayId { get; set; }

        //Added by Mah
        public byte[] TaxIDImage { get; set; }
        public string TaxIDImagePath { get; set; }
        public string TaxIDImagecontent { get; set; }
        public string ChargesForCall { get; set; }
        public string ChargesForCallINR { get; set; }
        public string ChargesForChat { get; set; }
        public string ChargesForChatINR { get; set; }

        public string CheckBabyName { get; set; }
        public string BabyName { get; set; }

        public string CheckBusinessName { get; set; }
        public string BusinessName { get; set; }

        public string CheckShubhMahurats { get; set; }
        public string ShubhMahurats { get; set; }

        public string CheckKundliMaking { get; set; }
        public string KundliMaking { get; set; }

        public string CheckBabyKundli { get; set; }
        public string BabyKundli { get; set; }

        public string CheckKundliMatching { get; set; }
        public string KundliMatching { get; set; }

        public string CheckCompatibilityAnalysis { get; set; }
        public string CompatibilityAnalysis { get; set; }

        public string CheckBusinessAnalysis { get; set; }
        public string BusinessAnalysis { get; set; }




        public string CheckKaalDosh { get; set; }
        public string KaalDosh { get; set; }

        public string CheckKaalSarp { get; set; }
        public string KaalSarp { get; set; }

        public string CheckMahamritunjay { get; set; }
        public string Mahamritunjay { get; set; }

        public string CheckSatyanarayan { get; set; }
        public string Satyanarayan { get; set; }

        public string CheckDurgaSapta { get; set; }
        public string DurgaSapta { get; set; }

        public string CheckSunderkand { get; set; }
        public string Sunderkand { get; set; }

        public string CheckSiddhi { get; set; }
        public string Siddhi { get; set; }

        public string CheckRudraabhishek { get; set; }
        public string Rudraabhishek { get; set; }
        public string skills { get; set; }
        public string puja { get; set; }

        public string FinalProceed { get; set; }

        public long packageID { get; set; }
        public string PackageName { get; set; }
        public long packageprice { get; set; }
        public string packageDescription { get; set; }

        public string Paymentoption { get; set; }
        public string ReportCharges { get; set; }
        public string ReportChargesINR { get; set; }

        public string DetailedReport { get; set; }
        public long ReportId { get; set; }
    }
}
