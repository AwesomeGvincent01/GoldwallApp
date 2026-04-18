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
    public class EvidencePhotoesController : Controller
    {
        private readonly AppDbContext _context;

        public EvidencePhotoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EvidencePhotoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EvidencePhotos.ToListAsync());
        }

        // GET: EvidencePhotoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evidencePhoto = await _context.EvidencePhotos
                .FirstOrDefaultAsync(m => m.EvidencePhotoId == id);
            if (evidencePhoto == null)
            {
                return NotFound();
            }

            return View(evidencePhoto);
        }

        // GET: EvidencePhotoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EvidencePhotoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EvidencePhotoId,WorkEventId,DefectReportId,FileUrl,Caption,TakenAt")] EvidencePhoto evidencePhoto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evidencePhoto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(evidencePhoto);
        }

        // GET: EvidencePhotoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evidencePhoto = await _context.EvidencePhotos.FindAsync(id);
            if (evidencePhoto == null)
            {
                return NotFound();
            }
            return View(evidencePhoto);
        }

        // POST: EvidencePhotoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EvidencePhotoId,WorkEventId,DefectReportId,FileUrl,Caption,TakenAt")] EvidencePhoto evidencePhoto)
        {
            if (id != evidencePhoto.EvidencePhotoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evidencePhoto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvidencePhotoExists(evidencePhoto.EvidencePhotoId))
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
            return View(evidencePhoto);
        }

        // GET: EvidencePhotoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evidencePhoto = await _context.EvidencePhotos
                .FirstOrDefaultAsync(m => m.EvidencePhotoId == id);
            if (evidencePhoto == null)
            {
                return NotFound();
            }

            return View(evidencePhoto);
        }

        // POST: EvidencePhotoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evidencePhoto = await _context.EvidencePhotos.FindAsync(id);
            if (evidencePhoto != null)
            {
                _context.EvidencePhotos.Remove(evidencePhoto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvidencePhotoExists(int id)
        {
            return _context.EvidencePhotos.Any(e => e.EvidencePhotoId == id);
        }
    }
}
