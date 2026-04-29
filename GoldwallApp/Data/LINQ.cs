using System.Linq;
using GoldwallApp.Data;

namespace GoldwallApp.Data
{
    public class LinqExamples
    {
        private readonly AppDbContext _context;

        public LinqExamples(AppDbContext context)
        {
            _context = context;
        }

        public void ExampleQueries()
        {
            // LINQ query 1
            //filters jobs to include only those with a status of "Active"
            var activeJobs = _context.Jobs
                .Where(j => j.Status == "Active")
                .ToList();

            // LINQ query 2:
            // sorts jobs by their title in ascending order
            var orderedJobs = _context.Jobs
                .OrderBy(j => j.Title)
                .ToList();
        }
    }
}