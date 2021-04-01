using Company.Data;
using Company.Models;
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
    public class PositionController : Controller
    {
        protected readonly ILogger<HomeController> _logger;
        protected readonly ApplicationDbContext db;

        public PositionController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            this.db = db;
        }
        // GET: DepartmentController
        public async Task<IActionResult> Index()
        {
            var list = await db.Positions.ToListAsync();

            return View(list);
        }

        // GET: CampController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CampController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PositionVM model)
        {
            if (!ModelState.IsValid) return View(model);


            var Position = new Position
            {

                Title = model.Title,
                Specification = model.Specification
            };

            db.Add(Position);

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

            var position = await db.Positions.FindAsync(id);
            if (position == null)
            {
                return NotFound();
            }
            return View(position);
        }

        // POST: CampController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Position position)
        {

            if (id != position.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(position);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }


                return RedirectToAction(nameof(Index));
            }
            return View(position);
        }

        // GET: CampController/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var position = await db.Positions.FirstOrDefaultAsync(m => m.Id == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // POST: CampController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var Delposition = await db.Positions.FindAsync(id);
            db.Positions.Remove(Delposition);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
