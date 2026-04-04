using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class Room
    {
     
        public int RoomId { get; set; }

   
        [Display(Name = "Job")]
        public int JobId { get; set; }


        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [StringLength(255)]
        public string? Notes { get; set; }

        
        public Job? Job { get; set; }

      
        public ICollection<Surface>? Surfaces { get; set; }
    }
}