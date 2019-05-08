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
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new SaleListItem
                                {
                                    SaleID = e.SaleID,
                                    Address = e.Address,
                                    SalePrice = e.SalePrice,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

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
                        .Single(e => e.SaleID == saleId && e.OwnerID == _userId);
                return
                    new SaleDetail
                    {
                        SaleID = entity.SaleID,
                        Address = entity.Address,
                        SalePrice = entity.SalePrice,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateSale(SaleEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sales
                        .Single(e => e.SaleID == model.SaleID && e.OwnerID == _userId);
                entity.Address = model.Address;
                entity.SalePrice = model.SalePrice;
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
                        .Single(e => e.SaleID == SaleID && e.OwnerID == _userId);

                ctx.Sales.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
