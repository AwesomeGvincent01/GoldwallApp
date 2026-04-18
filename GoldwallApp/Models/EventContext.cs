using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldwallApp.Models
{
    public class EventContext
    {
        [Key] //marks WorkEventId as the primary key for this table
        [ForeignKey("WorkEvent")] //also makes it the foreign key linked to WorkEvent
        public int WorkEventId { get; set; }

        [Display(Name = "Material")]
        public int MaterialId { get; set; }

        [Range(0, 99.99)] //restricts thickness to a sensible measured range
        [Display(Name = "Thickness (mm)")]
        public decimal ThicknessMm { get; set; }

        [Range(0, 100)] //ensures humidity stays within percentage limits
        [Display(Name = "Humidity (%)")]
        public decimal HumidityPct { get; set; }

        [Range(-20, 60)] //restricts temperature to a realistic range
        [Display(Name = "Temperature (°C)")]
        public decimal TemperatureC { get; set; }

        [Range(1, 10)] //restricts ventilation rating to the intended 1-10 scale
        [Display(Name = "Ventilation Rating")]
        public int VentilationRating { get; set; }

        [Range(0, 9999.99)] //prevents invalid negative time values
        [Display(Name = "Time Since Previous Event (Hours)")]
        public decimal TimeSincePrevEventHours { get; set; }

        [StringLength(50)] //limits the mix ratio text length
        [Display(Name = "Mix Ratio")]
        public string? MixRatio { get; set; }

        [StringLength(255)] //limits notes
        public string? Notes { get; set; }

        public WorkEvent? WorkEvent { get; set; }
        public Material? Material { get; set; }
    }
}