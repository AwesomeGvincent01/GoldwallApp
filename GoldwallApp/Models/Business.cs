using System;
using System.Collections.Generic;

namespace GoldwallApp.Models
{
    public class Business
    {
        // pk
        public int BusinessId { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation properties:
        // one business can have many users, clients, and jobs
        public ICollection<User> Users { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}