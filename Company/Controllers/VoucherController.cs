using Company.Data;
using Company.Models;
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
    public class VoucherController : Controller
    {
        protected readonly ILogger<HomeController> _logger;
        protected readonly ApplicationDbContext db;

        public VoucherController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public async Task<IActionResult> Book(int id)
        {
            var AppModel = await db.Applications.FindAsync(id);
            var checkRoom = await db.Vouchers
                .FirstOrDefaultAsync(c => c.CampId == AppModel.CampId && c.CategoryId == AppModel.CategoryId);

            var selectRooms = await db.Rooms
                .Where(c => c.CategoryId == AppModel.CategoryId /*&& c.Id != checkRoom.RoomId*/).ToListAsync();

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


        //// GET: VoucherController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: VoucherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Book(VoucherVM model)
        {
            if (ModelState.IsValid)
            {
                var room = await db.Rooms.FirstOrDefaultAsync(r => r.Id == model.RoomId);
                //string campt = "Camp" + model.CategoryId;
                //var cat = await db.Categories.FirstOrDefaultAsync(c => c.Id == model.CategoryId);
               
                db.Vouchers.Add(new Voucher
                {
                    FullName = model.FullName, 
                    CampId = model.CampId,
                    CategoryId = model.CategoryId,
                    RoomId = model.RoomId,
                    Cost = 10 * room.Amount,// 10 дней * количество мест в комнате * цена потока (Categories Camp +CampId) cost
                    Reserved = true,
                    PayStatus = true,
                    ApplicationId = model.ApplicationId,
                    CreatedDate = DateTime.Now

                });
                  await db.SaveChangesAsync();
                //var AppModel = await db.Applications.FindAsync(model.ApplicationId);

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
    }
}
