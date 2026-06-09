using GoldwallApp.Models;

namespace GoldwallApp.ViewModels
{
    public class InsightsViewModel
    {
        public int PatternsFound { get; set; }
        public int HighConfidence { get; set; }
        
        public int NeedsReview {  get; set; }

        public List<PatternOutcome> InsightsList { get; set; } = new List<PatternOutcome>();

    }
}
