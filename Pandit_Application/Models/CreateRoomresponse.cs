using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pandit_Application.Models
{
    public class CreateRoomresponse
    {

        
    public int result { get; set; }
        private List<Room> roomDetails = new List<Room>();
        public List<Room> room
        {
            get { return roomDetails; }
            set { roomDetails = value; }
        }
        private List<Sip> SipDetails = new List<Sip>();
        public List<Sip> sip
        {
            get { return SipDetails; }
            set { SipDetails = value; }
        }
        public DateTime created { get; set; }
       public string room_id { get; set; }
    }


    public class Room
    {
        public string name { get; set; }
        public string service_id{get;set;}
        public string owner_ref { get; set; }
        private List<Settings> SettingsDetails = new List<Settings>();
        public List<Settings> settings
        {
            get { return SettingsDetails; }
            set { SettingsDetails = value; }
        }
      
    }
    public class Sip
    {
        public bool enabled { get; set; }
    }
        public class Settings
        {
        public string mode { get; set; }
        public bool scheduled { get; set; }
        public bool adhoc { get; set; }
        public string duration { get; set; }
        public string participants { get; set; }
        public bool auto_recording { get; set; }
        public bool screen_share { get; set; }
        public bool canvas { get; set; }
        public string media_configuration { get; set; }
        public string quality { get; set; }
        public string moderators { get; set; }
        public bool active_talker { get; set; }
        public int max_active_talkers { get; set; }
        public bool single_file_recording { get; set; }
        public string media_zone { get; set; }
        }
}
