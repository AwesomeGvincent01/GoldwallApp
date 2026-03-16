using System;

namespace GoldwallApp.Models
{
    public class Client
    {

        //pk
        public int ClientId { get; set; }


        //fk
        public int BusinessId { get; set; }

        public string Name { get; set; }
        public int Phone { get; set; }

        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }


        //Navigation property for business again
        public Business Business { get; set; }
    }
}
