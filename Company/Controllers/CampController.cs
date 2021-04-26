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
    public class CampController : BaseController
    {
        public CampController(ILogger<HomeController> logger, ApplicationDbContext db) : base(logger, db)
        { }
        public async Task<ActionResult> Index()
        {
            var list = await db.Camps.ToListAsync();          

            return View(list);
        }
      
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CampVM model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var Camp = new Camp
            {                
                Title = model.Title,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Specification = model.Specification
            };

            db.Add(Camp);

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camp = await db.Camps.FindAsync(id);
            if (camp == null)
            {
                return NotFound();
            }
            return View(camp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Camp camp)
        {
            if (id != camp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(camp);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }                              
                
                return RedirectToAction(nameof(Index));
            }
            return View(camp);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var camp = await db.Camps.FirstOrDefaultAsync(m => m.Id == id);
            if (camp == null)
            {
                return NotFound();
            }
            return View(camp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var DelCamp = await db.Camps.FindAsync(id);
            db.Camps.Remove(DelCamp);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
