using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class PatternOutcome
    {
        public int PatternOutcomeId { get; set; }

        public int PatternId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Outcome Metric")]
        public string? OutcomeMetric { get; set; }

        [Range(0, 99.99)]
        public decimal Probability { get; set; }

        [StringLength(255)]
        public string? Notes { get; set; }

        public Pattern? Pattern { get; set; }
    }
}