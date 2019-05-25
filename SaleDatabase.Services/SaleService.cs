using Microsoft.AspNet.Identity;
using SaleDatabase.Data;
using SaleDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleDatabase.Services
{
    public class SaleService
    {
        private readonly Guid _userId;

        public SaleService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateSale(SaleCreate model)
        {
            var entity =
                new Sale()
                {
                    OwnerID = _userId,
                    Address = model.Address,
                    SalePrice = model.SalePrice,
                    SquareFootage = model.SquareFootage,
                    Buyer1 = model.Buyer1,
                    Seller1 = model.Seller1,
                    CompanyID = model.CompanyID,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sales.Add(entity);
                return ctx.SaveChanges() == 1;
            }



        }
        public IEnumerable<SaleListItem> GetSales()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Sales
                        .Where(e => e.OwnerID == _userId || e.CompanyID == 1)
                        .Select(
                            e =>
                                new SaleListItem
                                {
                                    SaleID = e.SaleID,
                                    Address = e.Address,
                                    SalePrice = e.SalePrice,
                                    SquareFootage = e.SquareFootage,
                                    Buyer1 = e.Buyer1,
                                    Seller1 = e.Seller1,
                                    CompanyID = e.CompanyID,
                                    Company = e.Company,
                                    CreatedUtc = e.CreatedUtc,
                                }
                        ).ToArray();
                foreach (var sale in query)
                {
                    sale.PricePerSF = sale.SalePrice / sale.SquareFootage;
                }


                return query.ToArray();
            }


        }
        public SaleDetail GetSaleById(int saleId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sales
                        .SingleOrDefault(e => e.SaleID == saleId && (e.OwnerID == _userId || e.CompanyID == 1));
                return
                    new SaleDetail
                    {
                        SaleID = entity.SaleID,
                        Address = entity.Address,
                        SalePrice = entity.SalePrice,
                        SquareFootage = entity.SquareFootage,
                        PricePerSF = entity.PricePerSF,
                        Buyer1 = entity.Buyer1,
                        Seller1 = entity.Seller1,
                        CompanyID = entity.CompanyID,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public List<Company> GetUserCompanyList()
        {
            var ctx = new ApplicationDbContext();
            var companyService = new CompanyService();
            var companylist = companyService.GetCompanyList();
            var user = ctx.Users.FirstOrDefault(u => u.Id == _userId.ToString());
            List<Company> returnlist = new List<Company>();
            foreach (Company company in companylist)
            {
                if (company.CompanyID == user.CompanyID)
                {
                    returnlist.Add(company);
                }
            }
            return returnlist;

        }

        public bool UpdateSale(SaleEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sales
                        .Single(e => e.SaleID == model.SaleID && (e.OwnerID == _userId || e.CompanyID == 1));
                entity.Address = model.Address;
                entity.SalePrice = model.SalePrice;
                entity.SquareFootage = model.SquareFootage;
                entity.Buyer1 = model.Buyer1;
                entity.Seller1 = model.Seller1;
                entity.CompanyID = model.CompanyID;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSale(int SaleID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sales
                        .Single(e => e.SaleID == SaleID && (e.OwnerID == _userId || e.CompanyID == 1));

                ctx.Sales.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public decimal CalcPricePSF(decimal SalePrice, int SquareFootage)
        {
            decimal pricePerSF = SalePrice / SquareFootage;

            return pricePerSF;
        }


    }
}
