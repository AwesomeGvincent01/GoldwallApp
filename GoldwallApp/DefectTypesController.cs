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
    public class DefectTypesController : Controller
    {
        private readonly AppDbContext _context;

        public DefectTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DefectTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DefectTypes.ToListAsync());
        }

        // GET: DefectTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defectType = await _context.DefectTypes
                .FirstOrDefaultAsync(m => m.DefectTypeId == id);
            if (defectType == null)
            {
                return NotFound();
            }

            return View(defectType);
        }

        // GET: DefectTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DefectTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DefectTypeId,BusinessId,Name,Notes")] DefectType defectType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(defectType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(defectType);
        }

        // GET: DefectTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defectType = await _context.DefectTypes.FindAsync(id);
            if (defectType == null)
            {
                return NotFound();
            }
            return View(defectType);
        }

        // POST: DefectTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DefectTypeId,BusinessId,Name,Notes")] DefectType defectType)
        {
            if (id != defectType.DefectTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(defectType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DefectTypeExists(defectType.DefectTypeId))
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
            return View(defectType);
        }

        // GET: DefectTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defectType = await _context.DefectTypes
                .FirstOrDefaultAsync(m => m.DefectTypeId == id);
            if (defectType == null)
            {
                return NotFound();
            }

            return View(defectType);
        }

        // POST: DefectTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var defectType = await _context.DefectTypes.FindAsync(id);
            if (defectType != null)
            {
                _context.DefectTypes.Remove(defectType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DefectTypeExists(int id)
        {
            return _context.DefectTypes.Any(e => e.DefectTypeId == id);
        }
    }
}
