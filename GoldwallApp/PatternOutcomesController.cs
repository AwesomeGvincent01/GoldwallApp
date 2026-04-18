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
    public class PatternOutcomesController : Controller
    {
        private readonly AppDbContext _context;

        public PatternOutcomesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PatternOutcomes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PatternOutcomes.ToListAsync());
        }

        // GET: PatternOutcomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patternOutcome = await _context.PatternOutcomes
                .FirstOrDefaultAsync(m => m.PatternOutcomeId == id);
            if (patternOutcome == null)
            {
                return NotFound();
            }

            return View(patternOutcome);
        }

        // GET: PatternOutcomes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatternOutcomes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatternOutcomeId,PatternId,OutcomeMetric,Probability,Notes")] PatternOutcome patternOutcome)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patternOutcome);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patternOutcome);
        }

        // GET: PatternOutcomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patternOutcome = await _context.PatternOutcomes.FindAsync(id);
            if (patternOutcome == null)
            {
                return NotFound();
            }
            return View(patternOutcome);
        }

        // POST: PatternOutcomes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatternOutcomeId,PatternId,OutcomeMetric,Probability,Notes")] PatternOutcome patternOutcome)
        {
            if (id != patternOutcome.PatternOutcomeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patternOutcome);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatternOutcomeExists(patternOutcome.PatternOutcomeId))
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
            return View(patternOutcome);
        }

        // GET: PatternOutcomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patternOutcome = await _context.PatternOutcomes
                .FirstOrDefaultAsync(m => m.PatternOutcomeId == id);
            if (patternOutcome == null)
            {
                return NotFound();
            }

            return View(patternOutcome);
        }

        // POST: PatternOutcomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patternOutcome = await _context.PatternOutcomes.FindAsync(id);
            if (patternOutcome != null)
            {
                _context.PatternOutcomes.Remove(patternOutcome);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatternOutcomeExists(int id)
        {
            return _context.PatternOutcomes.Any(e => e.PatternOutcomeId == id);
        }
    }
}
