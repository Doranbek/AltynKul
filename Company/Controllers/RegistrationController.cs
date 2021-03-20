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
            var selectDepartments = await db.Departments.ToListAsync();
            var selectPositions = await db.Positions.ToListAsync();
            var selectCamps = await db.Camps.ToListAsync();
            var selectCategories = await db.Categoryes.ToListAsync();


            var departmentsSelectList = new List<SelectListItem>();
            selectDepartments.ForEach(
                p => { 
                    departmentsSelectList.Add(new SelectListItem() { Text = p.Title, Value = p.Id.ToString() });
                });

            var positionsSelectList = new List<SelectListItem>();
            selectPositions.ForEach(
                p => {
                    positionsSelectList.Add(new SelectListItem() { Text = p.Title, Value = p.Id.ToString() });
                });

            var campsSelectList = new List<SelectListItem>();
            selectCamps.ForEach(
                p => {
                    campsSelectList.Add(new SelectListItem() { Text = p.Title, Value = p.Id.ToString() });
                });

            var categoriesSelectList = new List<SelectListItem>();
            selectCategories.ForEach(
                p => {
                    categoriesSelectList.Add(new SelectListItem() { Text = p.Title, Value = p.Id.ToString() });
                });


            var viewModel = new ApplicationSM
            {
                Departments = departmentsSelectList,
                Positions = positionsSelectList,
                Camps = campsSelectList,
                Categories =categoriesSelectList

            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Registration(ApplicationSM model)
        {
            if (ModelState.IsValid)
            {
                db.Applications.Add( new Application
                {
                    FullName = model.FullName,
                    PositionId = model.PositionId,
                    DepartmentId = model.DepartmentId,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    CampId = model.CampId,
                    CampersNumber = model.CampersNumber,
                    ChildNumber = model.ChildNumber,
                    CategoryId = model.CategoryId,
                    Status = false,
                    CreatedDate = DateTime.Now
                });
                var retValue = await db.SaveChangesAsync();
                if (retValue > 0)
                    TempData["SuccessMessage"] = $"Заявка успешно создано";
                else
                    TempData["ErrofrMessage"] = "Произошла ошибка";

                return RedirectToAction("Registration");
            }
            return View(model);
        }


    }
}
