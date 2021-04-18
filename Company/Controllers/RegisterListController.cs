using Company.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedList.Mvc;
using PagedList;

namespace Company.Controllers
{
    public class RegisterListController : Controller
    {
        protected readonly ILogger<HomeController> _logger;
        protected readonly ApplicationDbContext db;

        public RegisterListController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            var modelList = await db.ViewApplications.Where(r => r.Status == false).ToListAsync();
            return View(modelList);

        }
        public async Task<IActionResult> SortList()
        {
            var modelSortList = await db.ViewApplications.Where(x => x.Status == true).ToListAsync();
            return View(modelSortList);
        }
        public async Task<IActionResult> Reserv(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var AppModel = await db.ViewApplications.FindAsync(id);

            if (AppModel == null)
            {
                return NotFound();
            }
            
            return  View(AppModel);
        }

    }
}
