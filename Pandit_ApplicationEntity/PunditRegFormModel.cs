using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandit_ApplicationEntity
{
    public class PunditRegFormModel
    {
        public string Fullname { get; set; }
        public string Countrycode { get; set; }
        public long Mobile { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "The email address is not valid")]
        public string Email { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string YearsofExperience { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public string Profilepicture { get; set; }
        public string IDProof { get; set; }
        public string Biodata { get; set; }
        public string AboutSelf { get; set; }
        public string Hindi { get; set; }
        public string English { get; set; }
        public string Bengali { get; set; }
        public string Spanish { get; set; }
        public string French { get; set; }
        public string German { get; set; }
        public string Urdu { get; set; }
        public string Tamil { get; set; }
        public string Telugu { get; set; }
        public string Marathi { get; set; }
        public string Gujarati { get; set; }
        public string Kannada { get; set; }
        public string Malyalam { get; set; }
        public string Odia { get; set; }
        public string Assamese { get; set; }
        public string Nepali { get; set; }
        public string Punjabi { get; set; }
        public string Sindhi { get; set; }
        public string lang { get; set; }
        public string files { get; set; }
        public string files1 { get; set; }
        public string files2 { get; set; }
        public string imageSrc { get; set; }
        public string imageSrc1 { get; set; }
        public string imageSrc2 { get; set; }
        public string Palmistry { get; set; }
        public string Kundli { get; set; }
        public string Marriage_Specialist { get; set; }
        public string Vastu { get; set; }
        public string Puja { get; set; }
        public string Business_Specialist { get; set; }
        public string Career_Specialist { get; set; }
        public string Spiritual_Healing_Specialist { get; set; }
        public string Phychic_Reading_Specialist { get; set; }
        public string Tarot { get; set; }
        public string Vedic_Astrology { get; set; }
        public string Gemology { get; set; }
        public string KP_Astrology { get; set; }
        public string LalKitabAstrology { get; set; }
        public string Western_Astrology { get; set; }
        public string Face_Reading { get; set; }
        public string Signature_Reading { get; set; }
        public string Vedic_Navgrah_Anusthan { get; set; }
        public string Horary { get; set; }
        public string Specialization { get; set; }
        public long LangID { get; set; }

        // ADDED BY MAH
        public byte[] ProfileImage { get; set; }
        public string ProfileImagePath { get; set; }
        public string ProfileImageContent { get; set; }

        public byte[] GovernmentId { get; set; }
        public string GovernmentIdPath { get; set; }
        public string GovernmentIdContent { get; set; }

        public byte[] BioData2 { get; set; }
        public string BioDataPath { get; set; }
        public string BioDataPathContent { get; set; }
        public string DailyActive { get; set; }

    }
}
