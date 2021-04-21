using Company.Data;
using Company.Data.Enum;
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
    [Authorize]
    public class VoucherController : Controller
    {
        protected readonly ILogger<HomeController> _logger;
        protected readonly ApplicationDbContext db;

        public VoucherController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        [Authorize(Roles = "operator")]
        public async Task<IActionResult> Book(int id)
        {
            //находим модель заявку по Id
            var AppModel = await db.Applications.FindAsync(id);
            //находим путевки который совпадает с заявкой категория номера и поток

            var checkRoom = await db.Vouchers
                .FirstOrDefaultAsync(c => c.CampId == AppModel.CampId && c.CategoryId == AppModel.CategoryId);
            var selectRooms = new List<Room>();
            // находим комнаты совпадающий по категории номеров и не занятых
            // Выбирается номера если количество отдыхающих и место в номере совпадает
            if (checkRoom is null)
            {
                selectRooms = await db.Rooms
                .Where(c => c.CategoryId == AppModel.CategoryId && AppModel.CampersNumber == c.Amount).ToListAsync();
            }
            else
            {
                selectRooms = await db.Rooms
                .Where(c => c.CategoryId == AppModel.CategoryId && AppModel.CampersNumber == c.Amount && c.Id != checkRoom.RoomId).ToListAsync();
            }

            var roomsSelectList = new List<SelectListItem>();
            selectRooms.ForEach(
                p => {
                    roomsSelectList.Add(new SelectListItem() { Text = p.RoomNumber.ToString(), Value = p.Id.ToString() });
                });
            if (AppModel == null)
            {
                return NotFound();
            }

            var voucher = new VoucherVM()
            {
               
                FullName = AppModel.FullName,               
                CampId = AppModel.CampId,
                CategoryId = AppModel.CategoryId,
                Rooms = roomsSelectList,
                ApplicationId = id
            };

            return View(voucher);
        }

        // GET: VoucherController
        public async Task<IActionResult> Index()
        {
            var modelList = await db.ViewVouchers.ToListAsync();
            return View(modelList);
        }

        [Authorize(Roles = "operator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Book(VoucherVM model)
        {
            if (ModelState.IsValid)
            {
                var room = await db.Rooms.FirstOrDefaultAsync(r => r.Id == model.RoomId);
                var price = await db.CampCategories
                    .FirstOrDefaultAsync(p => p.CategoryId == model.CategoryId && p.CampId == model.CampId);
               
                db.Vouchers.Add(new Voucher
                {
                    FullName = model.FullName, 
                    CampId = model.CampId,
                    CategoryId = model.CategoryId,
                    RoomId = model.RoomId,
                    Cost = 10 * room.Amount * price.Price/2,
                    Reserved = true,
                    PayStatus = true,
                    ApplicationId = model.ApplicationId,
                    CreatedDate = DateTime.Now

                });
                  await db.SaveChangesAsync();
                var AppModel = await db.Applications.FindAsync(model.ApplicationId);
                AppModel.Status = AppStatus.Завершен;
                db.Applications.Update(AppModel);
                await db.SaveChangesAsync();
               
                return RedirectToAction("Index");
            }
            return View(model);
        }
        

        // GET: VoucherController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VoucherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VoucherController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VoucherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "operator")]
        public async Task<IActionResult> Reject(int id)
        {
            var AppModel = await db.Applications.FindAsync(id);
            AppModel.Status = AppStatus.Отклонено;
            db.Applications.Update(AppModel);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
