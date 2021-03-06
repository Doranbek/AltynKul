using Company.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Company.Data.Enum;

namespace Company.Controllers
{
    [Authorize(Roles = "operator, register, manager")]
    public class RegisterListController : BaseController
    {
        public RegisterListController(ILogger<HomeController> logger, ApplicationDbContext db) : base(logger, db)
        { }
        public async Task<IActionResult> Index()
        {
            var modelList = await db.ViewApplications.Where(r => r.Status == AppStatus.Ожидании).ToListAsync();
            return View(modelList);

        }
        public async Task<IActionResult> AppList()
        {
            var modelSortList = await db.ViewApplications.Where(x => x.Status == AppStatus.Отклонено).ToListAsync();
            return View(modelSortList);
        }
        public async Task<IActionResult> SortList()
        {
            var modelSortList = await db.ViewApplications.Where(x => x.Status == AppStatus.Завершен).ToListAsync();
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
