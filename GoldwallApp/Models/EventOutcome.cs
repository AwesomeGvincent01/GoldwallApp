using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class EventOutcome
    {

        [Key]
        public int WorkEventId { get; set; }


        [MaxLength(30)]
        public string? OutcomeStatus { get; set; }

        public decimal DryTimeHoursActual { get; set; }

       public bool ReworkRequired { get; set; }

        public int QualityRating { get; set; }

        [MaxLength(255)]
        public string? Notes { get; set; }


    }
}
