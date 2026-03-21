using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class WorkEvent
    {


        //pk
        public int WorkEventId { get; set; }

        [Display(Name = "Event Type")]
        public int SurfaceId { get; set; }

        public int UserId { get; set; } 

        public int EventTypeId { get; set; }

        public DateTime StartedAt { get; set; }

        public DateTime EndedAt { get; set; }

        public string Notes { get; set; }

        public Surface Surface { get; set; }

        public User User { get; set; }

        public EventType EventType { get; set; }
    }
}
