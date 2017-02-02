using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entity;
using Domain.Interface;

namespace UiWebSignalR.Repository
{
    public class UoWChat
    {
        IRepository<Message> _messages = new MessageRepository();
        IRepository<User> _users = new UserRepository();

        public void AddUser(string userName)
        {
            _users.Add(new User
            {
                Id = Guid.NewGuid(),
                UserName = userName
            });
        }

        public void RemoveUser(User user)
        {
            _users.Delete(user.Id);
        }

        public void RemoveUser(string userName)
        {
            RemoveUser(_users.GetAll().FirstOrDefault(u=>u.UserName == userName));
        }

        public List<User> GetAllUsers()
        {
            return _users.GetAll().ToList();
        }

        public List<Message> GetAllMessages()
        {
            return _messages.GetAll().ToList();
        }

        public void AddMessage(string text, string userName)
        {
            var message = new Message();
            var user = _users.GetAll().FirstOrDefault(u => u.UserName == userName);
            message.User = user;

            user.Messages.Add(message);
            _messages.Add(message);
        }

        public void AddMessage(Message message)
        {
            _users.GetAll()
                .FirstOrDefault(u=>u.UserName==message.User.UserName)
                .Messages
                .Add(message);
            _messages.Add(message);
        }
    }
}