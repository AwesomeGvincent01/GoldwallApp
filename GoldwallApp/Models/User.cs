using System;
using System.Collections.Generic;

namespace GoldwallApp.Models
{
    public class User
    {
        //pk
        public int UserId { get; set; }
        

        //fk
        public int BusinessId { get; set; }



        public string FullNaame { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }    
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }


        //navigation property, works together with the business foreign key. With navigation property , we can do stuff like user.Business.Name to get the business name for a user rather than just user.BusinessId = 1 or something like that
        public Business Business { get; set; }
    }


}
