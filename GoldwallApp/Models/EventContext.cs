using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldwallApp.Models
{
    public class EventContext
    {


        [Key]
        [ForeignKey("WorkEvent")]
        public int WorkEventId { get; set; }

        public int MaterialId { get; set; }

        public decimal ThicknessMm { get; set; }

        public decimal HumidityPct { get; set; }

        public decimal TemperatureC { get; set; }

        public int VentilationRating { get; set; }

        public decimal TimeSincePrevEventHours { get; set; }

        [StringLength(50)]
        public string? MixRatio { get; set; }

        [StringLength(255)]
        public string? Notes { get; set; }


        public WorkEvent? WorkEvent { get; set; }
    }
}
