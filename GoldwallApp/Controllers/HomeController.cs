using Microsoft.AspNetCore.Mvc;
using GoldwallApp.Data;
using GoldwallApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GoldwallApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context; 
        }

        public IActionResult Index()
        {
            var dashboardData = new DashboardViewModel  //creates a viewmodel object to hold the data for the dashboard
            {
                ActiveJobsCount = _context.Jobs.Count(j => j.Status == "Active"), //counts jobs with status "Active" and assigns to ActiveJobsCount. The _context here means its allowing it to access the database through entity framework. The .jobs means it uses the jobs table/ jobs dbset. the _context.Jobs means its lookimng at the jobs record in the dattabase. The .Count is a linq aggregate, which count records, so _context.Jobs.Count() means count job records that match this condition, which is: j => j.Status == "Active". the j => is a lambda expression, dumbed down meaning, for each job, call it j. j is a temporary nickname. it couldve been job but j is easier to reader. The .Status == "Active" means only count jobs where the status column is equal to "Active". So overall, this line is counting how many active jobs there are in the database and assigning that number to the ActiveJobsCount property of the dashboardData viewmodel.

                OpenDefectsCount = _context.DefectReports.Count(d => d.Status == "Open"), //counts defect reports with status "Open" and assigns to OpenDefectsCount

                TodayWorkEventsCount = _context.WorkEvents.Count(w => w.StartedAt.Date == DateTime.Today), //counts work events that started today and assigns to TodayWorkEventsCount

                EvidencePhotosCount = _context.EvidencePhotos.Count(),  //counts all uploaded evidence photos and assigns to EvidencePhotosCount

                ReworkRequiredCount = _context.EventOutcomes.Count(o => o.ReworkRequired == true) //counts event outcomes where rework is required and assigns to ReworkRequiredCount
            };

            return View(dashboardData); 
        }

        public IActionResult LinqPractice()
        {
            var practiceData = new LinqPracticeViewModel
            {
                TotalJobsCount = _context.Jobs.Count(),

                ActiveJobs = _context.Jobs.Count(job => job.Status == "Active"),


                ActiveJobsList = 
                _context.Jobs
                .Include(job => job.Client)
                .Where(job => job.Status == "Active")
                .OrderByDescending(job => job.JobId)
                .Take(3) //descending + take = take latest rows, so if we have 15 rows, take rows with id 13-15.
                .ToList()
            };



            return View(practiceData);
        }

        // Simple About page for now
        public IActionResult About()
        {
            return View();
        }
    }
}