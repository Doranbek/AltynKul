using Company.Data;
using Company.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoryController : BaseController
    {
        public CategoryController(ILogger<HomeController> logger, ApplicationDbContext db) : base(logger, db)
        { }
        public async Task<IActionResult> Index()
        {
            var list = await db.Categories.ToListAsync();

            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryVM model)
        {
            if (!ModelState.IsValid) return View(model);

            var Category = new Category
            {
                Title = model.Title,
                Specification = model.Specification
            };
            db.Add(Category);

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(category);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = await db.Categories.FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var Delcategory = await db.Categories.FindAsync(id);
            db.Categories.Remove(Delcategory);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
