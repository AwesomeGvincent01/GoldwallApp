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
    public class PatternsController : Controller
    {
        private readonly AppDbContext _context;

        public PatternsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Patterns
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patterns.ToListAsync());
        }

        // GET: Patterns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pattern = await _context.Patterns
                .FirstOrDefaultAsync(m => m.PatternId == id);
            if (pattern == null)
            {
                return NotFound();
            }

            return View(pattern);
        }

        // GET: Patterns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patterns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatternId,BusinessId,Title,Description,Confidence,CreatedAt")] Pattern pattern)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pattern);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pattern);
        }

        // GET: Patterns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pattern = await _context.Patterns.FindAsync(id);
            if (pattern == null)
            {
                return NotFound();
            }
            return View(pattern);
        }

        // POST: Patterns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatternId,BusinessId,Title,Description,Confidence,CreatedAt")] Pattern pattern)
        {
            if (id != pattern.PatternId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pattern);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatternExists(pattern.PatternId))
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
            return View(pattern);
        }

        // GET: Patterns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pattern = await _context.Patterns
                .FirstOrDefaultAsync(m => m.PatternId == id);
            if (pattern == null)
            {
                return NotFound();
            }

            return View(pattern);
        }

        // POST: Patterns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pattern = await _context.Patterns.FindAsync(id);
            if (pattern != null)
            {
                _context.Patterns.Remove(pattern);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatternExists(int id)
        {
            return _context.Patterns.Any(e => e.PatternId == id);
        }
    }
}
