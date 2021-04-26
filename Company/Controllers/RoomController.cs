using Company.Data;
using Company.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Controllers
{
    [Authorize]
    public class RoomController : BaseController
    {
        public RoomController(ILogger<HomeController> logger, ApplicationDbContext db) : base(logger, db)
        { }
        [Authorize(Roles = "admin, operator")]
        public async Task<IActionResult> Index()
        {
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

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "Id", "Title");
            return View();
        }

        [Authorize(Roles = "admin")]
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

        [Authorize(Roles = "admin")]
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

        [Authorize(Roles = "admin")]
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
        
        [Authorize(Roles = "admin")]
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
        
        [Authorize(Roles = "admin")]
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
