using GoldwallApp.Data;
using GoldwallApp.Models;
using GoldwallApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldwallApp
{
    [Authorize]
    public class JobsController : Controller
    {
        private readonly AppDbContext _context;

        public JobsController(AppDbContext context)
        {
            _context = context;
        }



        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Jobs.Include(j => j.Business).Include(j => j.Client);
            return View(await appDbContext.ToListAsync());


        }

        public async Task<IActionResult> Overview()
        {
          var viewModel = new JobsOverviewViewModel
            {
                TotalJobsCount = await _context.Jobs.CountAsync(),

         ActiveJobsCount = await _context.Jobs.CountAsync(job => job.Status == "Active"),

             PlannedJobsCount = await _context.Jobs.CountAsync(job => job.Status == "Planned"),

                CompletedJobsCount = await _context.Jobs.CountAsync(job => job.Status == "Completed"),

                Jobs = await _context.Jobs
                    .Include(job => job.Client)
                .OrderByDescending(job => job.JobId)
               .Take(10)
                 .ToListAsync()
            };

            return View(viewModel);
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .Include(j => j.Business)
                .Include(j => j.Client)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            ViewData["BusinessId"] = new SelectList(_context.Businesses, "BusinessId", "BusinessId");
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobId,BusinessId,ClientId,Title,Address,Status,StartDatePlanned,EndDatePlanned")] Job job)
        {
            if (ModelState.IsValid)
            {
                _context.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BusinessId"] = new SelectList(_context.Businesses, "BusinessId", "BusinessId", job.BusinessId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", job.ClientId);
            return View(job);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            ViewData["BusinessId"] = new SelectList(_context.Businesses, "BusinessId", "BusinessId", job.BusinessId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", job.ClientId);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobId,BusinessId,ClientId,Title,Address,Status,StartDatePlanned,EndDatePlanned")] Job job)
        {
            if (id != job.JobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.JobId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BusinessId"] = new SelectList(_context.Businesses, "BusinessId", "BusinessId", job.BusinessId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", job.ClientId);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .Include(j => j.Business)
                .Include(j => j.Client)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job != null)
            {
                _context.Jobs.Remove(job);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobExists(int id)
        {
            return _context.Jobs.Any(e => e.JobId == id);
        }
    }
}
