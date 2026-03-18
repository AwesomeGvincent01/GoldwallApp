using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class Business
    {
        // pk
        public int BusinessId { get; set; }


        [Display(Name = "Business Name")] //useful validation thingy majig for displaing  names properly
        public string Name { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        // Navigation properties:
        // one business can have many users, clients, and jobs
        public ICollection<User> Users { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}