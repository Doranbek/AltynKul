using Company.Data;
using Company.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Controllers
{
    [Authorize(Roles = "admin")]
    public class PriceController : Controller
    {
        protected readonly ILogger<HomeController> _logger;
        protected readonly ApplicationDbContext db;
        public PriceController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            var list = await db.ViewCampCategories.ToListAsync();

            return View(list);
        }

        public async Task<ActionResult> Create()
        {
            var selectCamps = await db.Camps.ToListAsync();
            var selectCategories = await db.Categories.ToListAsync();

            var campsSelectList = new List<SelectListItem>();
            selectCamps.ForEach(
                p =>
                {
                    campsSelectList.Add(new SelectListItem() { Text = p.Title, Value = p.Id.ToString() });
                });

            var categoriesSelectList = new List<SelectListItem>();
            selectCategories.ForEach(
                p =>
                {
                    categoriesSelectList.Add(new SelectListItem() { Text = p.Title, Value = p.Id.ToString() });
                });
            var viewModel = new CampCategoryVM
            {
                Camps = campsSelectList,
                Categories = categoriesSelectList
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CampCategoryVM model)
        {
            if (!ModelState.IsValid) return View(model);


            var price = new CampCategory
            {
                CampId = model.CampId,
                CategoryId = model.CategoryId,
                Price = model.Price
            };

            db.Add(price);

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
      
        public async Task<ActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var model = await db.ViewCampCategories.FirstOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var DelPrice = await db.CampCategories.FindAsync(id);
            db.CampCategories.Remove(DelPrice);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
