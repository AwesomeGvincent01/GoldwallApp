using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class Room
    {
     
        public int RoomId { get; set; }

   
        [Display(Name = "Job")]
        public int JobId { get; set; }

        public string Name { get; set; }
        public string Notes { get; set; }

        
        public Job Job { get; set; }

      
        public ICollection<Surface> Surfaces { get; set; }
    }
}