using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class EventType
    {
        public int EventTypeId { get; set; }

        [Display(Name = "Business")]
        public int BusinessId { get; set; }

        [Required] //ensures each event type has a name
        [StringLength(50)] //limits the name length
        public string? Name { get; set; }

        [Required] //ensures each event type is placed into a category
        [StringLength(30)] //limits category length
        public string? Categoery { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        public Business? Business { get; set; }
        public ICollection<WorkEvent>? WorkEvents { get; set; }
    }
}