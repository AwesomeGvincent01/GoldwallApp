using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        [Display(Name = "Job")]
        public int JobId { get; set; }

        [Required]  //required so each room can be identified and differentiated from other rooms
        [StringLength(50)] //keeps room names concise and prevents excessively long names that could cause display issues
        public string? Name { get; set; }

        [StringLength(255)] //limits notes so they don't become excessively long
        public string? Notes { get; set; }

        public Job? Job { get; set; }
        public ICollection<Surface>? Surfaces { get; set; }
    }
}