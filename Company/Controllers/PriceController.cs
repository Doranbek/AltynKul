using Company.Data;
using Company.Models;
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
    public class PriceController : Controller
    {
        protected readonly ILogger<HomeController> _logger;
        protected readonly ApplicationDbContext db;

        public PriceController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            this.db = db;
        }
        // GET: HomeController1
        public async Task<IActionResult> Index()
        {
            var list = await db.ViewCampCategories.ToListAsync();

            return View(list);
        }


        // GET: CampController/Create
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

        // POST: CampController/Create
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

        // GET: CampController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camp = await db.CampCategories.FindAsync(id);
            if (camp == null)
            {
                return NotFound();
            }
            return View(camp);
        }

        // POST: CampController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CampCategory model)
        {

            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(model);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }


                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: CampController/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var model = await db.CampCategories.FirstOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: CampController/Delete/5
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
