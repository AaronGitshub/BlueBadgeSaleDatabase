using Microsoft.AspNet.Identity;
using SaleDatabase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace SaleDatabase.WebApi.Controllers
{
    [Authorize]
    public class SaleController : ApiController
    {
        public IHttpActionResult Get()
        {
            SaleService saleService = CreateSaleService();
            var notes = saleService.GetSales();
            return Ok(notes);
        }
        private SaleService CreateSaleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var saleService = new SaleService(userId);
            return saleService;
        }
    }
}
