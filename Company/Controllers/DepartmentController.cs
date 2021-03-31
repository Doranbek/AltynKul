﻿using Company.Data;
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
    public class DepartmentController : Controller
    {
        protected readonly ILogger<HomeController> _logger;
        protected readonly ApplicationDbContext db;

        public DepartmentController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            this.db = db;
        }
        // GET: DepartmentController
        public async Task<IActionResult> Index()
        {
            var list = await db.Departments.ToListAsync();

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
        public async Task<IActionResult> Create(DepartmentVM model)
        {
            if (!ModelState.IsValid) return View(model);


            var Department = new Department
            {

                Title = model.Title,                
                Specification = model.Specification
            };

            db.Add(Department);

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

            var department = await db.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: CampController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Department department)
        {

            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(department);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }


                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: CampController/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var department = await db.Departments.FirstOrDefaultAsync(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: CampController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var Deldepartment = await db.Departments.FindAsync(id);
            db.Departments.Remove(Deldepartment);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
