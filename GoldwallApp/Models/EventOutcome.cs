using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldwallApp.Models
{
    public class EventOutcome
    {
        [Key] //marks WorkEventId as the primary key for this table
        [ForeignKey("WorkEvent")] //also links it directly to the related WorkEvent
        public int WorkEventId { get; set; }

        [Required] //ensures an outcome status is always entered
        [StringLength(30)] //limits outcome status length
        [Display(Name = "Outcome Status")]
        public string? OutcomeStatus { get; set; }

        [Range(0, 9999.99)] //prevents negative dry time values
        [Display(Name = "Dry Time Hours Actual")]
        public decimal DryTimeHoursActual { get; set; }

        [Display(Name = "Rework Required")]
        public bool ReworkRequired { get; set; }

        [Range(1, 5)] //restricts quality rating to the intended 1-5 scale
        [Display(Name = "Quality Rating")]
        public int QualityRating { get; set; }

        [StringLength(255)] //limits notes
        public string? Notes { get; set; }

        public WorkEvent? WorkEvent { get; set; }
    }
}