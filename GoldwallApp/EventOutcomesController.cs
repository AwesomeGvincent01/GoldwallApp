using GoldwallApp.Data;
using GoldwallApp.Models;
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
    public class EventOutcomesController : Controller
    {
        private readonly AppDbContext _context;

        public EventOutcomesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EventOutcomes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventOutcome.ToListAsync());
        }

        // GET: EventOutcomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventOutcome = await _context.EventOutcome
                .FirstOrDefaultAsync(m => m.WorkEventId == id);
            if (eventOutcome == null)
            {
                return NotFound();
            }

            return View(eventOutcome);
        }

        // GET: EventOutcomes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventOutcomes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkEventId,OutcomeStatus,DryTimeHoursActual,ReworkRequired,QualityRating,Notes")] EventOutcome eventOutcome)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventOutcome);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventOutcome);
        }

        // GET: EventOutcomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventOutcome = await _context.EventOutcome.FindAsync(id);
            if (eventOutcome == null)
            {
                return NotFound();
            }
            return View(eventOutcome);
        }

        // POST: EventOutcomes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkEventId,OutcomeStatus,DryTimeHoursActual,ReworkRequired,QualityRating,Notes")] EventOutcome eventOutcome)
        {
            if (id != eventOutcome.WorkEventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventOutcome);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventOutcomeExists(eventOutcome.WorkEventId))
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
            return View(eventOutcome);
        }

        // GET: EventOutcomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventOutcome = await _context.EventOutcome
                .FirstOrDefaultAsync(m => m.WorkEventId == id);
            if (eventOutcome == null)
            {
                return NotFound();
            }

            return View(eventOutcome);
        }

        // POST: EventOutcomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventOutcome = await _context.EventOutcome.FindAsync(id);
            if (eventOutcome != null)
            {
                _context.EventOutcome.Remove(eventOutcome);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventOutcomeExists(int id)
        {
            return _context.EventOutcome.Any(e => e.WorkEventId == id);
        }
    }
}
