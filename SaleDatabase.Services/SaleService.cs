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
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new SaleListItem
                                {
                                    SaleID = e.SaleID,
                                    Address = e.Address,
                                    SalePrice = e.SalePrice,
                                    CompanyID = e.CompanyID,
                                    Company = e.Company,
                                    CreatedUtc = e.CreatedUtc,
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
                        CompanyID = entity.CompanyID,
                        //CompanyName = entity.CompanyName,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        //Cody's Sample below
        // public List<MeetSelect> GetMeetSelectList()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        List<MeetSelect> meetSelectItems = new List<MeetSelect>();
        // List<Meet> listOfMeets = ctx.Meets.ToList();

        //        foreach (Meet meet in listOfMeets)
        //        {
        //            MeetSelect newSelectItem = new MeetSelect
        //            {
        //                MeetID = meet.MeetID,
        //                LocationOfMeet = meet.LocationOfMeet
        //            };
        // meetSelectItems.Add(newSelectItem);
        //        }
        //        return meetSelectItems;
        //    }
        //}

        /// <summary>
        /// add the list service for the dropdown below.
        /// </summary>
        /// 
        //public List<CompanySelect> GetCompanySelectList()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {

        //        List <CompanySelect> companyNameSelectItems = new List<CompanySelect>();
        //        List<Company> listOfNames = ctx.Companies.ToList();

        //        foreach (Company meet in listOfNames)
        //        {
        //            CompanySelect newSelectItem = new CompanySelect
        //            {
        //                CompanyID = meet.CompanyID,
        //                CompanyName = meet.CompanyName
        //            };
        //            companyNameSelectItems.Add(newSelectItem);
        //        }
        //        return companyNameSelectItems;
        //    }
        //}

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
                        .Single(e => e.SaleID == SaleID && e.OwnerID == _userId);

                ctx.Sales.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
