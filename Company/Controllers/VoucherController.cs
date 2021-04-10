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

            if (AppModel == null)
            {
                return NotFound();
            }

            var voucher = new VoucherVM()
            {
               
                FullName = AppModel.FullName,               
                CampId = AppModel.CampId,
                ApplicationId = id
            };

            return View(voucher);
        }

        // GET: VoucherController
        public ActionResult Index()
        {
            return View();
        }
             

        // GET: VoucherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VoucherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(VoucherVM model)
        {
            if (ModelState.IsValid)
            {
               
                db.Vouchers.Add(new Voucher
                {
                    FullName = model.FullName,                   
                    Price = 1,// 10 дней * количество мест в комнате * цена потока (Categories Camp +CampId) cost
                    Reserved = model.Reserved,
                    PayStatus = model.PayStatus,
                    ApplicationId = model.ApplicationId,
                    CreatedDate = DateTime.Now

                });
                var retValue = await db.SaveChangesAsync();
                if (retValue > 0)
                    TempData["SuccessMessage"] = $"Заявка успешно создано";
                else
                    TempData["ErrofrMessage"] = "Произошла ошибка";

                return RedirectToAction("Create");
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
