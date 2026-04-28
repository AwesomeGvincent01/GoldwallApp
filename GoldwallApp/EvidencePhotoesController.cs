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
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace GoldwallApp
{
    [Authorize]
    public class EvidencePhotoesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        


        

        public EvidencePhotoesController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment; //continue
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
                string wwwRootPath = _hostEnvironment.WebRootPath;

                string fileName = Path.GetFileNameWithoutExtension(evidencePhoto.FileUrl.FileName);

                string extension = Path.GetExtension(evidencePhoto.FileUrl.FileName);

                evidencePhoto.Caption = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                string path = Path.Combine(wwwRootPath + "/Images/" + fileName);

                using (var fileStream = new FileStream (path, FileMode.Create))
                {
                    await evidencePhoto.FileUrl.CopyToAsync (fileStream);
                }





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



            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "Images", evidencePhoto.Caption);

            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }







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
