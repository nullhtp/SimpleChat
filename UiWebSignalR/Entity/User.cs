using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

        public List<Message> Messages { get; }

    }
}