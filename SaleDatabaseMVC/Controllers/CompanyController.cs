using SaleDatabase.Models;
using SaleDatabase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaleDatabaseMVC.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            var service = CreateCompanyService();
            var model = service.GetCompanies();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCompanyService();

            if (service.CreateCompany(model))
            {
                TempData["SaveResult"] = "Your company was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Company could not be created.");
            return View(model);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var svc = CreateCompanyService();
            var model = svc.GetCompanyById(id.Value);

            return View(model);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var service = CreateCompanyService();
            var detail = service.GetCompanyById(id.Value);
            var model =
                new CompanyEdit
                {
                    CompanyID = detail.CompanyID,
                    CompanyName = detail.CompanyName,
                    CompanyLocation = detail.CompanyLocation
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CompanyEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CompanyID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateCompanyService();

            if (service.UpdateCompany(model))
            {
                TempData["SaveResult"] = "Your company was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your company could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var svc = CreateCompanyService();
            var model = svc.GetCompanyById(id.Value);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCompanyService();
            service.DeleteCompany(id);

            TempData["SaveResult"] = "Your company was deleted";

            return RedirectToAction("Index");
        }

        private CompanyService CreateCompanyService()
        {
            var service = new CompanyService();
            return service;
        }
        //private SaleService CreateSaleService()
        //{
        //    var service = new SaleService();
        //    return service;
        //}
    }
}