using Company.Data;
using Company.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class RoomController : Controller
    {
        protected readonly ILogger<HomeController> _logger;
        protected readonly ApplicationDbContext db;

        public RoomController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            this.db = db;
        }
        // GET: DepartmentController
        public async Task<IActionResult> Index()
        {
            //var selectCategories = await db.Categories.ToListAsync();
            //var categoriesSelectList = new List<SelectListItem>();
            //selectCategories.ForEach(
            //    p =>
            //    {
            //        categoriesSelectList.Add(new SelectListItem() { Text = p.Title, Value = p.Id.ToString() });
            //    });
            //var list = await db.Rooms.ToListAsync();

            var query = from room in db.Rooms
                        join category in db.Categories on room.CategoryId equals category.Id
                        select new RoomVM
                        {
                            Id = room.Id,
                            CategoryName = category.Title,
                            Amount = room.Amount,
                            RoomNumber = room.RoomNumber,
                            Specification = room.Specification
                        };

            return View(await query.ToListAsync());
        }

        // GET: CampController/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "Id", "Title");
            return View();
        }

        // POST: CampController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomVM model)
        {
            if (!ModelState.IsValid) return View(model);


            var Room = new Room
            {
                RoomNumber = model.RoomNumber,
                CategoryId = model.CategoryId,
                Amount = model.Amount,
                Specification = model.Specification
            };

            db.Add(Room);

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

            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "Id", "Title");

            var room = await db.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: CampController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Room  room)
        {

            if (id != room.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(room);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }


                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: CampController/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var room= await db.Rooms.FirstOrDefaultAsync(m => m.Id == id);
            if (room== null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: CampController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var Delroom= await db.Rooms.FindAsync(id);
            db.Rooms.Remove(Delroom);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
