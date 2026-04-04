using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class Business
    {
        // pk
        public int BusinessId { get; set; }


        [Required] //required so every business has a name
        [MaxLength(255)]    //names need to have a limit to prevent overly long entries
        [Display(Name = "Business Name")] //useful thingy majig for displaing  names properly
        public string? Name { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        // Icollection navigation properties:
        // this means one business can have many users, clients, and jobs
        public ICollection<User>? Users { get; set; }
        public ICollection<Client>? Clients { get; set; }
        public ICollection<Job>? Jobs { get; set; }

        public ICollection<EventType>? EventTypes { get; set; }

        public ICollection<Material>? Materials { get; set; }


    }
}