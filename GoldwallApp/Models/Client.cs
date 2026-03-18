using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Display(Name = "Business")]
        public int BusinessId { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        public Business Business { get; set; }
    }
}