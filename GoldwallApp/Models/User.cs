using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Display(Name = "Business")]
        public int BusinessId { get; set; }

        [StringLength(100)]  
        [Required]
        [Display(Name = "Full Name")]
        public string? FullName { get; set; }


        [Required] 
        [EmailAddress] //required and checked so email input follows the proper format
        [StringLength(100)]
        public string? Email { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string? Role { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Password Hash")]
        public string? PasswordHash { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        public Business? Business { get; set; }

        public ICollection<WorkEvent>? WorkEvents { get; set; }
    }
}