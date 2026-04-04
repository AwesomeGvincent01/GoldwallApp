using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Display(Name = "Business")]
        public int BusinessId { get; set; }

        [MaxLength(100)]  
        [Required]
        [Display(Name = "Full Name")]
        public string? FullName { get; set; }


        [Required] 
        [EmailAddress] //required and checked so email input follows the proper format
        [MaxLength(100)]
        public string? Email { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string? Role { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Password Hash")]
        public string? PasswordHash { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        public Business? Business { get; set; }

        public ICollection<WorkEvent>? WorkEvents { get; set; }
    }
}