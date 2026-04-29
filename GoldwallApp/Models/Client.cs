using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Display(Name = "Business")]
        public int BusinessId { get; set; }

        [Required] //ensures each client record has a name
        [StringLength(100)] //limits the name length to keep client names realistic
        public string? Name { get; set; }

        [Required] //ensures a phone number is entered
        [Phone] //checks that the value entered follows phone number format
        [MaxLength(30)] //limits the phone number length
        [MinLength(9)] //ensures the phone number is not unrealistically short
        public string? Phone { get; set; }

        [EmailAddress] //checks email format if an email is entered
        [StringLength(100)] //limits the email length
        public string? Email { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }



//public entityname entityname navigation property
//this is a navigation property to one related object. so a client has one business, but a business can have many clients and that is the "many" side of the relationship
public Business? Business { get; set; }
    }
}