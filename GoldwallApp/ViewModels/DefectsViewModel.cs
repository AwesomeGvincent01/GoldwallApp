using GoldwallApp.Models;

namespace GoldwallApp.ViewModels
{
    public class DefectsViewModel
    {
        public int AllDefectsCount { get; set; }

        public int OpenDefectsCount { get; set; }

        public int HighSeverityCount { get; set; }

        public int MonitoringCount { get; set; }

        public int FixedCount { get; set; }

        public List<DefectReport> DefectsList { get; set; } = new List<DefectReport>();

        public DefectReport? SelectedDefect { get; set; }
    }
}