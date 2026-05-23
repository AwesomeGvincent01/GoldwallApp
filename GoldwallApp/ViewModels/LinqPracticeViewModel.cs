namespace GoldwallApp.ViewModels;
using GoldwallApp.Models;   

    public class LinqPracticeViewModel
    {
        public int TotalJobsCount { get; set; } 

        public int ActiveJobs {get; set; }

        public List<Job> ActiveJobsList { get; set; } = new List<Job>(); //storing a full list of jobs and not just a single number
    }