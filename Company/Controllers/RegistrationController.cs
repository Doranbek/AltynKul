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
            var SelectCat = await db.Categoryes.ToListAsync();

            var viewModel = new ApplicationSM
            {
                Departments = SelectDep,
                Positions = SelectPos,
                Categoryes = SelectCat

            };

            return View(viewModel);
        }


    }
}
