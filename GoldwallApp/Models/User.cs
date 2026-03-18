using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Display(Name = "Business")]
        public int BusinessId { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        public string Email { get; set; }
        public string Role { get; set; }

        [Display(Name = "Password Hash")]
        public string PasswordHash { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        public Business Business { get; set; }
    }
}