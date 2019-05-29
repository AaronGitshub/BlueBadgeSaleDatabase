using Microsoft.AspNet.Identity;
using SaleDatabase.Models;
using SaleDatabase.Services;
//using SaleDatabase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SaleDatabase.WebApi.Controllers
{
   
    public class CompanyController : ApiController
    {
        [Authorize]
        public IHttpActionResult GetAll()
        {
            CompanyService companyService = CreateCompanyService();
            var companies = companyService.GetCompanies();
            return Ok(companies);
        }
        public IHttpActionResult Get(int id)
        {
            CompanyService companyService = CreateCompanyService();
            var company = companyService.GetCompanyById(id);
            return Ok(company);
        }

        public IHttpActionResult Post(CompanyCreate company)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCompanyService();

            if (!service.CreateCompany(company))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(CompanyEdit company)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCompanyService();

            if (!service.UpdateCompany(company))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCompanyService();

            if (!service.DeleteCompany(id))
                return InternalServerError();

            return Ok();
        }

        private CompanyService CreateCompanyService()
        {
            var companyService = new CompanyService();
            return companyService;
        }
    }
}
