using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class PatternOutcome
    {
        public int PatternOutcomeId { get; set; }

        public int PatternId { get; set; }

        [Required] //ensures the outcome metric is always entered
        [StringLength(50)] //limits metric name length
        [Display(Name = "Outcome Metric")]
        public string? OutcomeMetric { get; set; }

        [Range(0, 99.99)] //range's purpose is basically, in simple terms, to prevent the user from entering a value that is outside of the expected range. In this case, it ensures that the probability value entered is between 0 and 99.99, which makes sense for a percentage value.
        public decimal Probability { get; set; }

        [StringLength(255)] //limits notes
        public string? Notes { get; set; }

        public Pattern? Pattern { get; set; }
    }
} 