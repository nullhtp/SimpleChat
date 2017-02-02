using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entity;
using Domain.Interface;

namespace UiWebSignalR.Repository
{
    public class UserRepository : IRepository<User>
    {
        private List<User> _users = new List<User>();

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User Get(Guid id)
        {
            return _users.FirstOrDefault(m => m.Id == id);
        }

        public User Get(string userName)
        {
            return _users.FirstOrDefault(m => m.UserName == userName);
        }

        public bool Add(User item)
        {
            _users.Add(item);
            return true;
        }

        public bool Update(User item)
        {
            _users.Remove(
                _users.FirstOrDefault(m => m.Id == item.Id)
            );
            _users.Add(item);
            return true;

        }

        public bool Delete(Guid id)
        {
            _users.Remove(
                _users.FirstOrDefault(m => m.Id == id)
            );
            return true;
        }
    }
}