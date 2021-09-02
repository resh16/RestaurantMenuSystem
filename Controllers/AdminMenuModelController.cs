using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantMenuSystem.Models;

namespace RestaurantMenuSystem.Controllers
{
    [Authorize]
    public class AdminMenuModelController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private object imageModel;

        public AdminMenuModelController(DataContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

       
        // GET: AdminMenuModel
        public async Task<IActionResult> Index()
        {
            return View(await _context.adminMenuModels.ToListAsync());
        }

        // GET: AdminMenuModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminMenuModel = await _context.adminMenuModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminMenuModel == null)
            {
                return NotFound();
            }

            return View(adminMenuModel);
        }

        // GET: AdminMenuModel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminMenuModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ImageFile,Price,Description")] AdminMenuModel adminMenuModel)
        {
            if (ModelState.IsValid)
            {

                string wwwRootPath = _hostEnvironment.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(adminMenuModel.ImageFile.FileName);
                string extention = Path.GetExtension(adminMenuModel.ImageFile.FileName);
                adminMenuModel.ImageName=filename = filename + DateTime.Now.ToString("yymmssfff") + extention;
                string path = Path.Combine(wwwRootPath + "/Image/", filename);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await adminMenuModel.ImageFile.CopyToAsync(fileStream);
                }



                _context.Add(adminMenuModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminMenuModel);
        }

        // GET: AdminMenuModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminMenuModel = await _context.adminMenuModels.FindAsync(id);
            if (adminMenuModel == null)
            {
                return NotFound();
            }
            return View(adminMenuModel);
        }

        // POST: AdminMenuModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Image,Price,Description")] AdminMenuModel adminMenuModel)
        {
            if (id != adminMenuModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminMenuModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminMenuModelExists(adminMenuModel.Id))
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
            return View(adminMenuModel);
        }

        // GET: AdminMenuModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminMenuModel = await _context.adminMenuModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminMenuModel == null)
            {
                return NotFound();
            }

            return View(adminMenuModel);
        }

        // POST: AdminMenuModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adminMenuModel = await _context.adminMenuModels.FindAsync(id);
            _context.adminMenuModels.Remove(adminMenuModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminMenuModelExists(int id)
        {
            return _context.adminMenuModels.Any(e => e.Id == id);
        }


       

    }
}
