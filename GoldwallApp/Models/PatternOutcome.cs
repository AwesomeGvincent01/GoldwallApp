using System.ComponentModel.DataAnnotations;

namespace GoldwallApp.Models
{
    public class PatternOutcome
    {

        public int PatternOutcomeId { get; set; }   

        public int PatternId { get; set; }

        [MaxLength(50)]
        public string? OutcomeMetric { get; set; }

        public decimal Probability { get; set; }    

        public string? Notes { get; set; }  


    }
}
