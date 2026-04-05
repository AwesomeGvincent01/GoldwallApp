using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class Surface
    {
        // pk
        public int SurfaceId { get; set; }

       
        [Display(Name = "Room")]

        //room fk
        public int RoomId { get; set; }

        [Required] //required so the app knows what type of surface it is working with 
        [StringLength(50)]
        [Display(Name = "Surface Type")]
        public string? SurfaceType { get; set; }

        [Required] //required so the surface can be identified and differentiated from other surface in the same room
        [StringLength(50)]
        public string? Label { get; set; }

        [Range(0.01, 99999.99)] //stops invalid negative or zero values, and also very large values
        [Display(Name = "Area (m²)")]
        public decimal AreaM2 { get; set; }

        [Required] //required because substrate affects plasterer choice and work process
        [StringLength(50)]
        [Display(Name = "Substrate Type")]
        public string? SubstrateType { get; set; }


        [StringLength(255)]
        public string? Notes { get; set; }

     
        public Room? Room { get; set; }

        public ICollection<WorkEvent>? WorkEvents { get; set; }

        public ICollection <DefectReport>? DefectReports { get; set; }
    }
}