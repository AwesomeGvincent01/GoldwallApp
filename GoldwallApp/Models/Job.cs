using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class Job
    {
        public int JobId { get; set; }

        [Display(Name = "Business")]
        public int BusinessId { get; set; }

        [Display(Name = "Client")]
        public int ClientId { get; set; }

        [Required] //required because every job needs a title to identify it and differentiate it from other jobs
        [StringLength(100)] //limits title length so it stays reasonable
        public string? Title { get; set; }

        [Required]  //required because every job needs an address to identify where the work is taking place
        [StringLength(150)] //limits address length
        public string? Address { get; set; }

        [Required]  //required because every job needs a status to identify where it is in the workflow and to help with organization and tracking
        [StringLength(30)] //keeps statuses short and consistent
        public string? Status { get; set; }

        [Display(Name = "Planned Start Date")]
        public DateTime StartDatePlanned { get; set; }

        [Display(Name = "Planned End Date")]
        public DateTime EndDatePlanned { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        public Business? Business { get; set; }
        public Client? Client { get; set; }
        public ICollection<Room>? Rooms { get; set; }
    }
}