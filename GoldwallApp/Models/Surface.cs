using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class Surface
    {
        public int SurfaceId { get; set; }

        [Display(Name = "Room")]
        public int RoomId { get; set; }

        [Required] //required so the app knows what type of surface it is working with 
        [StringLength(50)] //limits surface type length
        [Display(Name = "Surface Type")]
        public string? SurfaceType { get; set; }

        [Required] //required so the surface can be identified and differentiated from other surface in the same room
        [StringLength(50)] //keeps the label short and consistent
        public string? Label { get; set; }

        [Range(0.01, 99999.99)] //stops invalid negative or zero values, and also very large values
        [Display(Name = "Area (m²)")]
        public decimal AreaM2 { get; set; }

        [Required] //required because substrate affects plasterer choice and work process
        [StringLength(50)] //limits substrate text length
        [Display(Name = "Substrate Type")]
        public string? SubstrateType { get; set; }

        [StringLength(255)] //limits note length
        public string? Notes { get; set; }

        public Room? Room { get; set; }
        public ICollection<WorkEvent>? WorkEvents { get; set; }
        public ICollection<DefectReport>? DefectReports { get; set; }
    }
}