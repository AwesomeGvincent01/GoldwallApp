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
        private readonly IWebHostEnvironment _hostEnvironment; //gives access to wwwroot path so uploaded images can be saved there






        public EvidencePhotoesController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment; 
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
            ViewData["DefectReportId"] = new SelectList(_context.DefectReports, "DefectReportId", "DefectReportId"); 
            ViewData["WorkEventId"] = new SelectList(_context.WorkEvents, "WorkEventId", "WorkEventId"); 
            return View();
        }

        // POST: EvidencePhotoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EvidencePhotoId,WorkEventId,DefectReportId,FileUrl,Caption,TakenAt,ImageFile")] EvidencePhoto evidencePhoto)
        {
            if (evidencePhoto.ImageFile != null) //checks if an image was uploaded before trying to save it, prevents errors and allows photos to be optional
            {
                string wwwRootPath = _hostEnvironment.WebRootPath; //gets the wwwroot path so we can save the uploaded image there, this allows the image to be served by the app and prevents issues with file access permissions that can arise when trying to save files outside of wwwroot. for example, if we tried to save uploaded images to a folder in the project root, we would likely run into issues with the app not having permission to write to that folder when deployed. Saving to wwwroot ensures the app can write the file and serve it properly.

                string fileName = Path.GetFileNameWithoutExtension(evidencePhoto.ImageFile.FileName); //gets uploaded file name without extension, which means if two users upload files with the same name, they won't overwrite each other because we will add a timestamp to the file name to make it unique. For example, if two users upload a file named "photo.jpg", they can both be saved as "photo20240610123000123.jpg" and "photo20240610123000234.jpg", preventing any conflicts.

                string extension = Path.GetExtension(evidencePhoto.ImageFile.FileName); //gets the uploaded file extension such as .jpg or .png which allows us to preserve the original file type when saving the file, for example if a user uploads "photo.png", we can save it as "photo20240610123000123.png" and it will still be recognized as a PNG image when served by the app.

                string uniqueFileName = fileName + DateTime.Now.ToString("yymmssfff") + extension; //adds the current date and time to the file name to make it unique

                string imagesFolder = Path.Combine(wwwRootPath, "Images"); //sets the path to the Images folder in wwwroot where uploaded images will be saved.

                if (!Directory.Exists(imagesFolder)) //checks whether the images folder exists before trying to save uploaded file
                {
                    Directory.CreateDirectory(imagesFolder); //creates the image folder in wwwroot if it is missing
                }

                string path = Path.Combine(imagesFolder, uniqueFileName); //this is the thing that actually combines the wwwroot path, the Images folder, and the unique file name to create the full file path where the uploaded image will be saved. for example, if wwwroot is "C:\MyApp\wwwroot", the unique file name is "photo20240610123000123.jpg", then the full path would be "C:\MyApp\wwwroot\Images\photo20240610123000123.jpg".

                using (var fileStream = new FileStream(path, FileMode.Create)) //opens a new file stream to the specified path in create mode, which means it will create a new image or overwrite an existing image at that location. 
                {
                    await evidencePhoto.ImageFile.CopyToAsync(fileStream); //copies uploaded image file to the images folder, which saves the file to the specified path on the server. 
                }

                evidencePhoto.FileUrl = "/Images/" + uniqueFileName; //store the relative image URL in the database, which allows us to easily reference and serve the image in our views. For example, if the unique file name is "photo20240610123000123.jpg", the FileUrl would be "/Images/photo20240610123000123.jpg", and we can use this URL to display the image in our app. 
            }
            else //runs if the user submits the form without uploading an image, else it would throw an error when trying to save the evidence photo without an image.
            {
                ModelState.AddModelError("ImageFile", "Please upload an image."); 
            }

            if (ModelState.IsValid)
            {
                _context.Add(evidencePhoto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["DefectReportId"] = new SelectList(_context.DefectReports, "DefectReportId", "DefectReportId", evidencePhoto.DefectReportId); 
            ViewData["WorkEventId"] = new SelectList(_context.WorkEvents, "WorkEventId", "WorkEventId", evidencePhoto.WorkEventId); 
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

            ViewData["DefectReportId"] = new SelectList(_context.DefectReports, "DefectReportId", "DefectReportId", evidencePhoto.DefectReportId); 
            ViewData["WorkEventId"] = new SelectList(_context.WorkEvents, "WorkEventId", "WorkEventId", evidencePhoto.WorkEventId); 
            return View(evidencePhoto);
        }

        // POST: EvidencePhotoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EvidencePhotoId,WorkEventId,DefectReportId,FileUrl,Caption,TakenAt,ImageFile")] EvidencePhoto evidencePhoto)
        {
            if (id != evidencePhoto.EvidencePhotoId)
            {
                return NotFound();
            }

            var oldEvidencePhoto = await _context.EvidencePhotos.AsNoTracking().FirstOrDefaultAsync(e => e.EvidencePhotoId == id); 

            if (oldEvidencePhoto == null) 
            {
                return NotFound(); 
            }

            if (evidencePhoto.ImageFile != null) 
            {
                string wwwRootPath = _hostEnvironment.WebRootPath; 

                string fileName = Path.GetFileNameWithoutExtension(evidencePhoto.ImageFile.FileName); 

                string extension = Path.GetExtension(evidencePhoto.ImageFile.FileName); 

                string uniqueFileName = fileName + DateTime.Now.ToString("yymmssfff") + extension; 

                string imagesFolder = Path.Combine(wwwRootPath, "Images"); 

                if (!Directory.Exists(imagesFolder)) 
                {
                    Directory.CreateDirectory(imagesFolder); 
                }

                string path = Path.Combine(imagesFolder, uniqueFileName); 

                using (var fileStream = new FileStream(path, FileMode.Create)) 
                {
                    await evidencePhoto.ImageFile.CopyToAsync(fileStream); 
                }

                evidencePhoto.FileUrl = "/Images/" + uniqueFileName; 
            }
            else 
            {
                evidencePhoto.FileUrl = oldEvidencePhoto.FileUrl; 
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

            ViewData["DefectReportId"] = new SelectList(_context.DefectReports, "DefectReportId", "DefectReportId", evidencePhoto.DefectReportId); 
            ViewData["WorkEventId"] = new SelectList(_context.WorkEvents, "WorkEventId", "WorkEventId", evidencePhoto.WorkEventId); 
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
                if (!string.IsNullOrEmpty(evidencePhoto.FileUrl)) 
                {
                    var imagePath = Path.Combine(_hostEnvironment.WebRootPath, evidencePhoto.FileUrl.TrimStart('/')); 

                    if (System.IO.File.Exists(imagePath)) 
                    {
                        System.IO.File.Delete(imagePath); 
                    }
                }

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