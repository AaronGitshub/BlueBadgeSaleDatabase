using Microsoft.AspNet.Identity;
using SaleDatabase.Models;
using SaleDatabase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaleDatabaseMVC.Controllers
{
    [Authorize]
    public class SaleController : Controller
    {
        // GET: Sale
        public ActionResult Index()
        {
            var service = CreateSaleService();
            var model = service.GetSales();

            return View(model);
        }
        //GET
        public ActionResult Create()
        {
            var service = new CompanyService();

            ViewBag.CompanyID = new SelectList(service.GetCompanies(), "CompanyID", "CompanyName");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaleCreate model)
        {
            var service = CreateSaleService();
            var companyService = new CompanyService();

            ViewBag.CompanyID = new SelectList(companyService.GetCompanies(), "CompanyID", "CompanyName");

            if (!ModelState.IsValid) return View(model);


            if (service.CreateSale(model))
            {
                TempData["SaveResult"] = "Your sale was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Sale could not be created.");
            return View(model);

        }
        public ActionResult Details(int id)
        {
            var svc = CreateSaleService();
            var model = svc.GetSaleById(id);

            return View(model);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var companyservice = new CompanyService();

            //Need to limit to CompanyID of the User.
            ViewBag.CompanyID = new SelectList(companyservice.GetCompanies(), "CompanyID", "CompanyName");

            var service = CreateSaleService();
            var detail = service.GetSaleById(id.Value);
            var model =
                new SaleEdit
                {
                    SaleID = detail.SaleID,
                    Address = detail.Address,
                    SalePrice = detail.SalePrice
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SaleEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            var companyservice = new CompanyService();

            ViewBag.CompanyID = new SelectList(companyservice.GetCompanies(), "CompanyID", "CompanyName");
            if (model.SaleID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateSaleService();

            if (service.UpdateSale(model))
            {
                TempData["SaveResult"] = "Your sale was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your sale could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var svc = CreateSaleService();
            var model = svc.GetSaleById(id.Value);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSaleService();
            service.DeleteSale(id);

            TempData["SaveResult"] = "Your sale was deleted";

            return RedirectToAction("Index");
        }

        private SaleService CreateSaleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SaleService(userId);
            return service;
        }



    }
}