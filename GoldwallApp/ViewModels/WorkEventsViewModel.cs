using GoldwallApp.Models;
using System.Collections.Generic;

namespace GoldwallApp.ViewModels
{
    public class WorkEventsViewModel
    {
        public int TotalWorkEventsCount { get; set; }

              public int TodayWorkEventsCount { get; set; }

        public int CompletedWorkEventsCount { get; set; }

        public List<WorkEvent> WorkEventsList { get; set; } = new();
    }
}