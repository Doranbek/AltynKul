using Company.Data;
using Company.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Controllers
{
    public class RegistrationController : Controller
    {
        protected readonly ILogger<HomeController> _logger;
        protected readonly ApplicationDbContext db;

        public RegistrationController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public async Task<IActionResult> Registration()
        {
            var SelectDep = await db.Departments.ToListAsync();
            var SelectPos = await db.Positions.ToListAsync();
            var SelectCamp = await db.Camps.ToListAsync();
            var SelectCat = await db.Categoryes.ToListAsync();

            var viewModel = new ApplicationSM
            {
                Departments = SelectDep,
                Positions = SelectPos,
                Camps = SelectCamp,
                Categoryes = SelectCat

            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Registration(ApplicationSM model)
        {
            if (ModelState.IsValid)
            {
                var TempPosition = db.Positions.FirstOrDefault(u => u.Title == model.Position.Title);
                var TempDepartment = await db.Departments.FirstOrDefaultAsync(u => u.Title == model.Department.Title);
                var TempCamp = await db.Camps.FirstOrDefaultAsync(u => u.Title == model.Camp.Title);
                var TempCategory = await db.Categoryes.FirstOrDefaultAsync(u => u.Title == model.Category.Title);


                db.Applications.Add( new Application
                {
                    FullName = model.FullName,
                    PositionId = TempPosition.Id,
                    DepartmentId = TempDepartment.Id,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    CampId = TempCamp.Id,
                    CampersNumber = model.CampersNumber,
                    CategoryId = TempCategory.Id,
                    Status = false,
                    CreatedDate = DateTime.Now
                });
                await db.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Заявка успешно создано";
                return RedirectToAction("Registration");
            }
            return View(model);
        }


    }
}
