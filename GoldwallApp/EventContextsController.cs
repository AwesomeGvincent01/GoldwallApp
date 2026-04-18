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
    public class EventContextsController : Controller
    {
        private readonly AppDbContext _context;

        public EventContextsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EventContexts
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventContexts.ToListAsync());
        }

        // GET: EventContexts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventContext = await _context.EventContexts
                .FirstOrDefaultAsync(m => m.WorkEventId == id);
            if (eventContext == null)
            {
                return NotFound();
            }

            return View(eventContext);
        }

        // GET: EventContexts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventContexts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkEventId,MaterialId,ThicknessMm,HumidityPct,TemperatureC,VentilationRating,TimeSincePrevEventHours,MixRatio,Notes")] EventContext eventContext)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventContext);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventContext);
        }

        // GET: EventContexts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventContext = await _context.EventContexts.FindAsync(id);
            if (eventContext == null)
            {
                return NotFound();
            }
            return View(eventContext);
        }

        // POST: EventContexts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkEventId,MaterialId,ThicknessMm,HumidityPct,TemperatureC,VentilationRating,TimeSincePrevEventHours,MixRatio,Notes")] EventContext eventContext)
        {
            if (id != eventContext.WorkEventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventContext);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventContextExists(eventContext.WorkEventId))
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
            return View(eventContext);
        }

        // GET: EventContexts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventContext = await _context.EventContexts
                .FirstOrDefaultAsync(m => m.WorkEventId == id);
            if (eventContext == null)
            {
                return NotFound();
            }

            return View(eventContext);
        }

        // POST: EventContexts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventContext = await _context.EventContexts.FindAsync(id);
            if (eventContext != null)
            {
                _context.EventContexts.Remove(eventContext);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventContextExists(int id)
        {
            return _context.EventContexts.Any(e => e.WorkEventId == id);
        }
    }
}
