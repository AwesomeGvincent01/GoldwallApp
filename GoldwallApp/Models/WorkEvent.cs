using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class WorkEvent
    {


        //pk
        public int WorkEventId { get; set; }

        [Display(Name = "Surface")]
        public int SurfaceId { get; set; }

        [Display(Name = "User")]
        public int UserId { get; set; }

        [Display(Name = "Event Type")]

        public int EventTypeId { get; set; }

        [Display(Name = "Started At")]

        public DateTime StartedAt { get; set; }


        [Display(Name = "Ended At")]
        public DateTime EndedAt { get; set; }

        [StringLength(255)] //limits note length so event notes stay concise
        public string? Notes { get; set; }

        public Surface? Surface { get; set; }

        public User? User { get; set; }

        public EventType? EventType { get; set; }


        public EventContext? EventContext { get; set; }
        public EventOutcome? EventOutcome { get; set; }
        public ICollection<EvidencePhoto>? EvidencePhotos { get; set; }
    }
}