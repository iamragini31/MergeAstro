using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pandit_Application.Signalr.hubs
{
    public class ChatHub : Hub
    {
        static List<Users> ConnectedUsers = new List<Users>();
        static List<Messages> CurrentMessage = new List<Messages>();

        public void Connect(string userName, string userid)
        {
            var id = Context.ConnectionId;
            var activeusers = ConnectedUsers.Where(x => x.UserId == userid).ToList();
            if (ConnectedUsers.Count(x => x.UserId == userid) > 0)
            {
                ConnectedUsers.RemoveAll(r=>r.UserId == userid);
            }
            if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
            {
                string UserImg = GetUserImage(userName);
                string logintime = DateTime.Now.ToString();

                ConnectedUsers.Add(new Users { ConnectionId = id,UserId = userid, UserName = userName, UserImage = UserImg, LoginTime = logintime });
                // send to caller
                Clients.Caller.onConnected(id, userName, ConnectedUsers, CurrentMessage);

                // send to all except caller client
                Clients.AllExcept(id).onNewUserConnected(id, userName, UserImg, logintime);
            }
        }

        public void SendMessageToAll(string userName, string message, string time)
        {
            string UserImg = GetUserImage(userName);
            // store last 100 messages in cache
            AddMessageinCache(userName, message, time, UserImg);

            // Broad cast message
            Clients.All.messageReceived(userName, message, time, UserImg);

        }

        private void AddMessageinCache(string userName, string message, string time, string UserImg)
        {
            CurrentMessage.Add(new Messages { UserName = userName, Message = message, Time = time, UserImage = UserImg });

            if (CurrentMessage.Count > 100)
                CurrentMessage.RemoveAt(0);

        }

        // Clear Chat History
        public void clearTimeout()
        {
            CurrentMessage.Clear();
        }

        public string GetUserImage(string username)
        {
            string RetimgName = "images/dummy.png";
            try
            {
                string query = "select Photo from tbl_Users where UserName='" + username + "'";
                string ImageName = "";
                //string ImageName = ConnC.GetColumnVal(query, "Photo");

                if (ImageName != "")
                    RetimgName = "images/DP/" + ImageName;
            }
            catch (Exception ex)
            { }
            return RetimgName;
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                ConnectedUsers.Remove(item);

                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.UserName);

            }
            return base.OnDisconnected(stopCalled);
        }
        public void NotifyPandit(string pid)
        {
            var pandit = ConnectedUsers.FirstOrDefault(x => x.UserId == pid);
            Clients.Client(pandit.ConnectionId).invitationAccepted();
        }
            public void SendPrivateMessage(string toUserId,string cid, string message)
        {
            string fromUserId = Context.ConnectionId;
            var toUser = ConnectedUsers.FirstOrDefault(x =>  x.UserId == cid);
            var fromUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);

            if (toUser != null && fromUser != null)
            {
                string CurrentDateTime = DateTime.Now.ToString();
                string UserImg = GetUserImage(fromUser.UserName);
                // send to 
                Clients.Client(toUser.ConnectionId).sendPrivateMessage(fromUser.ConnectionId, fromUser.UserId, fromUser.UserName, message, UserImg, CurrentDateTime);

                // send to caller user
                Clients.Caller.sendPrivateMessage(toUser.ConnectionId, cid, fromUser.UserName, message, UserImg, CurrentDateTime);
            }

        }
    }
}