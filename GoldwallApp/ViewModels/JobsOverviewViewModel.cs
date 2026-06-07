using GoldwallApp.Models;

namespace GoldwallApp.ViewModels
{
    public class JobsOverviewViewModel
    {
        public int TotalJobsCount { get; set; }

        public int ActiveJobsCount { get; set; }

        public int PlannedJobsCount { get; set; }

        public int CompletedJobsCount { get; set; }

        public List<Job> Jobs { get; set; } = new List<Job>();
    }
}