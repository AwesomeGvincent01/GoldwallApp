using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoldwallApp.Data;
using GoldwallApp.Models;

namespace GoldwallApp
{
    public class SurfacesController : Controller
    {
        private readonly AppDbContext _context;

        public SurfacesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Surfaces
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Surfaces.Include(s => s.Room);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Surfaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surface = await _context.Surfaces
                .Include(s => s.Room)
                .FirstOrDefaultAsync(m => m.SurfaceId == id);
            if (surface == null)
            {
                return NotFound();
            }

            return View(surface);
        }

        // GET: Surfaces/Create
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId");
            return View();
        }

        // POST: Surfaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SurfaceId,RoomId,SurfaceType,Label,AreaM2,SubstrateType,Notes")] Surface surface)
        {
            if (ModelState.IsValid)
            {
                _context.Add(surface);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId", surface.RoomId);
            return View(surface);
        }

        // GET: Surfaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surface = await _context.Surfaces.FindAsync(id);
            if (surface == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId", surface.RoomId);
            return View(surface);
        }

        // POST: Surfaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SurfaceId,RoomId,SurfaceType,Label,AreaM2,SubstrateType,Notes")] Surface surface)
        {
            if (id != surface.SurfaceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(surface);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurfaceExists(surface.SurfaceId))
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
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId", surface.RoomId);
            return View(surface);
        }

        // GET: Surfaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surface = await _context.Surfaces
                .Include(s => s.Room)
                .FirstOrDefaultAsync(m => m.SurfaceId == id);
            if (surface == null)
            {
                return NotFound();
            }

            return View(surface);
        }

        // POST: Surfaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var surface = await _context.Surfaces.FindAsync(id);
            if (surface != null)
            {
                _context.Surfaces.Remove(surface);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SurfaceExists(int id)
        {
            return _context.Surfaces.Any(e => e.SurfaceId == id);
        }
    }
}
