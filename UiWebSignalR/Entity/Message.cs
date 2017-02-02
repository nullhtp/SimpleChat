using System;

namespace Domain.Entity
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
    }
}