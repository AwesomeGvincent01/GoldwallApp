namespace GoldwallApp.ViewModels;
    using GoldwallApp.Models; 

    public class DashboardViewModel
    {

        public int ActiveJobsCount { get; set; } //stores the count of active jobs that are currently marked as active in the system.
        public int OpenDefectsCount { get; set; } //stores the count of open defects that are currently marked as open in the system.

        public int TodayWorkEventsCount { get; set; } //stores the number of work events recorded for the current day
        public int EvidencePhotosCount { get; set; } //stores the total number of evidence photos in the system
        public int ReworkRequiredCount { get; set; } //stores the number of event outcomes where rework is required

  

        public List<Job> ListOfActiveJob { get; set; } = new List<Job>();

    public List<DefectReport> OpenDefectsDisplay { get; set; } = new List<DefectReport>();

    public List<WorkEvent> RecentWorkEvent { get; set; } = new List<WorkEvent>();

    public List<EvidencePhoto> RecentPhotos {  get; set; } = new List<EvidencePhoto>();

    
}

