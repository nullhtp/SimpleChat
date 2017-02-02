using System.Linq;
using Microsoft.AspNetCore.SignalR;
using UiWebSignalR.Repository;

namespace UiWebSignalR
{
    public class ChatHub : Hub
    {
        public static UoWChat _uowChat = new UoWChat();

        public void Send(string userName, string message)
        {
            Clients.All.messageReceived(userName, message);
        }

        public void Connect(string newUser)
        {
            _uowChat.AddUser(newUser);

            Clients.Caller.getOnlineUsers(_uowChat.GetAllUsers().Select(u=>u.UserName).ToList());
            Clients.Others.newUserAdded(newUser);
            Clients.All.messageReceived("SystemBot",$"Поприветствуем {newUser}!");

        }

        public void Disconnect(string newUser)
        {
            _uowChat.RemoveUser(newUser);
            Clients.All.messageReceived("SystemBot",$"Нас покинул {newUser}!");
            Clients.All.getOnlineUsers(_uowChat.GetAllUsers().Select(u=>u.UserName).ToList());

        }
    }
}