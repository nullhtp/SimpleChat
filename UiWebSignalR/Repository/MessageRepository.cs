using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entity;
using Domain.Interface;

namespace UiWebSignalR.Repository
{
    public class MessageRepository:IRepository<Message>
    {
        private List<Message> _messages = new List<Message>();

        public IEnumerable<Message> GetAll()
        {
            return _messages;
        }

        public Message Get(Guid id)
        {
            return _messages.FirstOrDefault(m => m.Id == id);
        }

        public bool Add(Message item)
        {
            _messages.Add(item);
            return true;
        }

        public bool Update(Message item)
        {
            _messages.Remove(
                _messages.FirstOrDefault(m => m.Id == item.Id)
            );
            _messages.Add(item);
            return true;

        }

        public bool Delete(Guid id)
        {
            _messages.Remove(
                _messages.FirstOrDefault(m => m.Id == id)
            );
            return true;
        }
    }
}