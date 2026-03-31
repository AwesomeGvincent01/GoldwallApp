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
    public class DefectReportsController : Controller
    {
        private readonly AppDbContext _context;

        public DefectReportsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DefectReports
        public async Task<IActionResult> Index()
        {
            return View(await _context.DefectReports.ToListAsync());
        }

        // GET: DefectReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defectReport = await _context.DefectReports
                .FirstOrDefaultAsync(m => m.DefectReportId == id);
            if (defectReport == null)
            {
                return NotFound();
            }

            return View(defectReport);
        }

        // GET: DefectReports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DefectReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DefectReportId,SurfaceId,DefectTypeId,ReportedAt,Severity,Description,SuspectedCauseEventId,FixEventId,Status")] DefectReport defectReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(defectReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(defectReport);
        }

        // GET: DefectReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defectReport = await _context.DefectReports.FindAsync(id);
            if (defectReport == null)
            {
                return NotFound();
            }
            return View(defectReport);
        }

        // POST: DefectReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DefectReportId,SurfaceId,DefectTypeId,ReportedAt,Severity,Description,SuspectedCauseEventId,FixEventId,Status")] DefectReport defectReport)
        {
            if (id != defectReport.DefectReportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(defectReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DefectReportExists(defectReport.DefectReportId))
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
            return View(defectReport);
        }

        // GET: DefectReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defectReport = await _context.DefectReports
                .FirstOrDefaultAsync(m => m.DefectReportId == id);
            if (defectReport == null)
            {
                return NotFound();
            }

            return View(defectReport);
        }

        // POST: DefectReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var defectReport = await _context.DefectReports.FindAsync(id);
            if (defectReport != null)
            {
                _context.DefectReports.Remove(defectReport);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DefectReportExists(int id)
        {
            return _context.DefectReports.Any(e => e.DefectReportId == id);
        }
    }
}
