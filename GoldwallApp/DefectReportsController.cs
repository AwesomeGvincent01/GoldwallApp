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



        public async Task<IActionResult> Defects(int? selectedDefectId)
        {

     var defectsList = await _context.DefectReports
             .Include(defectReport => defectReport.DefectType)
             .Include(defectReport => defectReport.Surface)
              .ThenInclude(surface => surface.Room)
                .ThenInclude(room => room.Job)
                .Include(defectReport => defectReport.EvidencePhotos)
                 .OrderByDescending(defectReport => defectReport.ReportedAt)
                .ToListAsync();


            var viewModel = new DefectsViewModel
            {

                AllDefectsCount = await _context.DefectReports.CountAsync(),

                OpenDefectsCount = await _context.DefectReports.CountAsync(defectReport => defectReport.Status == "Open"),

                HighSeverityCount = await _context.DefectReports.CountAsync(defectReport => defectReport.Severity == 3),

                MonitoringCount = await _context.DefectReports.CountAsync(defectReport => defectReport.Status == "Monitoring"),

                FixedCount = await _context.DefectReports.CountAsync(defectReport => defectReport.Status == "Fixed"),

                DefectsList = defectsList,



                SelectedDefect = selectedDefectId.HasValue
            ? defectsList.FirstOrDefault(defectReport =>defectReport.DefectReportId == selectedDefectId.Value)
                ?? defectsList.FirstOrDefault()
            : defectsList.FirstOrDefault()
     


    };

            return View(viewModel);
        }



        // GET: DefectReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defectReport = await _context.DefectReports
            .Include(defectReport => defectReport.Surface)
             .Include(defectReport => defectReport.DefectType)
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
            ViewData["SurfaceId"] = new SelectList(
                _context.Surfaces.OrderBy(surface => surface.Label),
                "SurfaceId",
                "Label");

            ViewData["DefectTypeId"] = new SelectList(
                _context.DefectTypes.OrderBy(defectType => defectType.Name),
                "DefectTypeId",
                "Name");

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
                return RedirectToAction(nameof(Defects));
            }
            ViewData["SurfaceId"] = new SelectList(
    _context.Surfaces.OrderBy(surface => surface.Label),
    "SurfaceId",
    "Label",
    defectReport.SurfaceId);

ViewData["DefectTypeId"] = new SelectList(
    _context.DefectTypes.OrderBy(defectType => defectType.Name),
    "DefectTypeId",
    "Name",
    defectReport.DefectTypeId);

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
            ViewData["SurfaceId"] = new SelectList(
    _context.Surfaces.OrderBy(surface => surface.Label),
    "SurfaceId",
    "Label",
    defectReport.SurfaceId);

ViewData["DefectTypeId"] = new SelectList(
    _context.DefectTypes.OrderBy(defectType => defectType.Name),
    "DefectTypeId",
    "Name",
    defectReport.DefectTypeId);

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
                return RedirectToAction(nameof(Defects));
            }
            ViewData["SurfaceId"] = new SelectList(
    _context.Surfaces.OrderBy(surface => surface.Label),
    "SurfaceId",
    "Label",
    defectReport.SurfaceId);

ViewData["DefectTypeId"] = new SelectList(
    _context.DefectTypes.OrderBy(defectType => defectType.Name),
    "DefectTypeId",
    "Name",
    defectReport.DefectTypeId);
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
             .Include(defectReport => defectReport.Surface)
                 .Include(defectReport => defectReport.DefectType)
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
            return RedirectToAction(nameof(Defects));
        }

        private bool DefectReportExists(int id)
        {
            return _context.DefectReports.Any(e => e.DefectReportId == id);
        }
    }
}
