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
    public class WorkEventsController : Controller
    {
        private readonly AppDbContext _context;

        public WorkEventsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: WorkEvents
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.WorkEvents.Include(w => w.EventType).Include(w => w.Surface).Include(w => w.User);
            return View(await appDbContext.ToListAsync());
        }

        // GET: WorkEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workEvent = await _context.WorkEvents
                .Include(w => w.EventType)
                .Include(w => w.Surface)
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.WorkEventId == id);
            if (workEvent == null)
            {
                return NotFound();
            }

            return View(workEvent);
        }

        // GET: WorkEvents/Create
        public IActionResult Create()
        {
            ViewData["EventTypeId"] = new SelectList(_context.EventTypes, "EventTypeId", "EventTypeId");
            ViewData["SurfaceId"] = new SelectList(_context.Surfaces, "SurfaceId", "SurfaceId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: WorkEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkEventId,SurfaceId,UserId,EventTypeId,StartedAt,EndedAt,Notes")] WorkEvent workEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventTypeId"] = new SelectList(_context.EventTypes, "EventTypeId", "EventTypeId", workEvent.EventTypeId);
            ViewData["SurfaceId"] = new SelectList(_context.Surfaces, "SurfaceId", "SurfaceId", workEvent.SurfaceId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", workEvent.UserId);
            return View(workEvent);
        }

        // GET: WorkEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workEvent = await _context.WorkEvents.FindAsync(id);
            if (workEvent == null)
            {
                return NotFound();
            }
            ViewData["EventTypeId"] = new SelectList(_context.EventTypes, "EventTypeId", "EventTypeId", workEvent.EventTypeId);
            ViewData["SurfaceId"] = new SelectList(_context.Surfaces, "SurfaceId", "SurfaceId", workEvent.SurfaceId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", workEvent.UserId);
            return View(workEvent);
        }

        // POST: WorkEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkEventId,SurfaceId,UserId,EventTypeId,StartedAt,EndedAt,Notes")] WorkEvent workEvent)
        {
            if (id != workEvent.WorkEventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkEventExists(workEvent.WorkEventId))
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
            ViewData["EventTypeId"] = new SelectList(_context.EventTypes, "EventTypeId", "EventTypeId", workEvent.EventTypeId);
            ViewData["SurfaceId"] = new SelectList(_context.Surfaces, "SurfaceId", "SurfaceId", workEvent.SurfaceId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", workEvent.UserId);
            return View(workEvent);
        }

        // GET: WorkEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workEvent = await _context.WorkEvents
                .Include(w => w.EventType)
                .Include(w => w.Surface)
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.WorkEventId == id);
            if (workEvent == null)
            {
                return NotFound();
            }

            return View(workEvent);
        }

        // POST: WorkEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workEvent = await _context.WorkEvents.FindAsync(id);
            if (workEvent != null)
            {
                _context.WorkEvents.Remove(workEvent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkEventExists(int id)
        {
            return _context.WorkEvents.Any(e => e.WorkEventId == id);
        }
    }
}
