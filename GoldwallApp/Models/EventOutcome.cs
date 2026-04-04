using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldwallApp.Models
{
    public class EventOutcome
    {

        [Key]
        [ForeignKey("WorkEvent")]
        public int WorkEventId { get; set; }


        [StringLength(30)]
        public string? OutcomeStatus { get; set; }

        public decimal DryTimeHoursActual { get; set; }

       public bool ReworkRequired { get; set; }

        public int QualityRating { get; set; }

        [StringLength(255)]
        public string? Notes { get; set; }


        public WorkEvent? WorkEvent { get; set; }   


    }
}
