using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantMenuSystem.Models;

namespace RestaurantMenuSystem.Controllers
{

    [Authorize]
    public class CustomerMenuController : Controller
    {
        private readonly DataContext _context;

        public CustomerMenuController(DataContext context)
        {
            _context = context;
        }

        // GET: CustomerMenu
        public async Task<IActionResult> Index()
        {
            return View(await _context.adminMenuModels.ToListAsync());
        }

        //// GET: CustomerMenu/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var adminMenuModel = await _context.adminMenuModels
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (adminMenuModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(adminMenuModel);
        //}

        //// GET: CustomerMenu/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: CustomerMenu/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,ImageName,Price,Description")] AdminMenuModel adminMenuModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(adminMenuModel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(adminMenuModel);
        //}

        //// GET: CustomerMenu/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var adminMenuModel = await _context.adminMenuModels.FindAsync(id);
        //    if (adminMenuModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(adminMenuModel);
        //}

        //// POST: CustomerMenu/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ImageName,Price,Description")] AdminMenuModel adminMenuModel)
        //{
        //    if (id != adminMenuModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(adminMenuModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AdminMenuModelExists(adminMenuModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(adminMenuModel);
        //}

        //// GET: CustomerMenu/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var adminMenuModel = await _context.adminMenuModels
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (adminMenuModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(adminMenuModel);
        //}

        //// POST: CustomerMenu/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var adminMenuModel = await _context.adminMenuModels.FindAsync(id);
        //    _context.adminMenuModels.Remove(adminMenuModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool AdminMenuModelExists(int id)
        {
            return _context.adminMenuModels.Any(e => e.Id == id);
        }
    }
}
