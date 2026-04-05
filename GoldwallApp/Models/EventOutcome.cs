using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldwallApp.Models
{
    public class EventOutcome
    {

        [Key]
        [ForeignKey("WorkEvent")]
        public int WorkEventId { get; set; }


        [Required]
        [StringLength(30)]
        [Display(Name = "Outcome Status")]
        public string? OutcomeStatus { get; set; }

        [Range(0, 9999.99)]
        [Display(Name = "Dry Time Hours Actual")]
        public decimal DryTimeHoursActual { get; set; }


        [Display(Name = "Rework Required")]
        public bool ReworkRequired { get; set; }


        [Range(1, 5)]
        [Display(Name = "Quality Rating")]
        public int QualityRating { get; set; }

        [StringLength(255)]
        public string? Notes { get; set; }


        public WorkEvent? WorkEvent { get; set; }   


    }
}
