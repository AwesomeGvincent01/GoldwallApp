using GoldwallApp.Models;

namespace GoldwallApp.ViewModels
{
    public class InsightsViewModel
    {
        public int PatternsFound { get; set; }
        public int HighConfidence { get; set; }
        
        public int NeedsReview {  get; set; }

        public List<Pattern> InsightsList { get; set; } = new List<Pattern>();

    }
}
