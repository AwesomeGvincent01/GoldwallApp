using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class User
    {
        //pk
        public int UserId { get; set; }


        //fk
        [Display(Name = "Business")] //useful validation thingy majig for displaing  names properly
        public int BusinessId { get; set; }


        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        [Display(Name = "Password")]
        public string PasswordHash { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }


        //navigation property, works together with the business foreign key. With navigation property , we can do stuff like user.Business.Name to get the business name for a user rather than just user.BusinessId = 1 or something like that
        public Business Business { get; set; }
    }


}
