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

        [Display(Name = "Surface Type")]
        public string SurfaceType { get; set; }

        public string Label { get; set; }

        [Display(Name = "Area (m²)")]
        public decimal AreaM2 { get; set; }

        [Display(Name = "Substrate Type")]
        public string SubstrateType { get; set; }

        public string Notes { get; set; }

     
        public Room Room { get; set; }
    }
}