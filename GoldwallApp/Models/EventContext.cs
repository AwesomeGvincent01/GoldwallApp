using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class EventContext
    {


        [Key]
        public int WorkEventId { get; set; }

        public int MaterialId { get; set; }

        public decimal ThicknessMm { get; set; }

        public decimal HumidityPct { get; set; }

        public decimal TemperatureC { get; set; }

        public int VentilationRating { get; set; }

        public decimal TimeSincePrevEventHours { get; set; }

        [MaxLength(50)]
        public string? MixRatio { get; set; }

        [MaxLength(255)]
        public string? Notes { get; set; }
    }
}
