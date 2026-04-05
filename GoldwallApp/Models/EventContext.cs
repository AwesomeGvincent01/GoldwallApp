using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldwallApp.Models
{
    public class EventContext
    {


        [Key]
        [ForeignKey("WorkEvent")]
        public int WorkEventId { get; set; }

        [Display(Name = "Material")]

        public int MaterialId { get; set; }

        [Range(0, 99.99)]
        [Display(Name = "Thickness (mm)")]
        public decimal ThicknessMm { get; set; }

        [Range(0, 100)]
        [Display(Name = "Humidity (%)")]
        public decimal HumidityPct { get; set; }

        [Range(-20, 60)]
        [Display(Name = "Temperature (°C)")]
        public decimal TemperatureC { get; set; }


        [Range(1, 10)]
        [Display(Name = "Ventilation Rating")]
        public int VentilationRating { get; set; }


        [Range(0, 9999.99)]
        [Display(Name = "Time Since Previous Event (Hours)")]
        public decimal TimeSincePrevEventHours { get; set; }

        [StringLength(50)]
        [Display(Name = "Mix Ratio")]
        public string? MixRatio { get; set; }

        [StringLength(255)]
        public string? Notes { get; set; }


        public WorkEvent? WorkEvent { get; set; }
        public Material? Material { get; set; }
    }
}
