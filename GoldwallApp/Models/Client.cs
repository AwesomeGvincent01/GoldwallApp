using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Display(Name = "Business")]
        public int BusinessId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [Phone]
       [StringLength(30)]
        public string? Phone { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }



        //public entityname entityname navigation property
        //this is a navigation property to one related object. so a client has one business, but a business can have many clients and that is the "many" side of the relationship
        public Business? Business { get; set; }
    }
}