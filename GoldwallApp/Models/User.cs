using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Display(Name = "Business")]
        public int BusinessId { get; set; }

        [Required] //ensures every user record has a name
        [StringLength(100)]  //limits the full name length to keep entries neat and realistic
        [Display(Name = "Full Name")]
        public string? FullName { get; set; }


        [Required] //required and checked so email input follows the proper format
        [EmailAddress] //checks that the value entered follows email format
        [StringLength(100)] //keeps the email within a sensible maximum length
        public string? Email { get; set; }

        [Required] //ensures a role is always recorded for the user
        [StringLength(30)] //limits role names to a small, controlled length
        public string? Role { get; set; }

        [Required] //makes sure  password hash field isn't left blank
        [StringLength(255)] //keep hash within reasonable length
        [Display(Name = "Password Hash")]
        public string? PasswordHash { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        public Business? Business { get; set; }

        public ICollection<WorkEvent>? WorkEvents { get; set; }
    }
}