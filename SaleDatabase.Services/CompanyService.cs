using SaleDatabase.Data;
using SaleDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleDatabase.Services
{
    public class CompanyService
    {
        public bool CreateCompany(CompanyCreate model)
        {
            var entity =
                new Company()
                {
                    CompanyName = model.CompanyName,
                    CompanyLocation = model.CompanyLocation,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Companies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CompanyListItem> GetCompanies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Companies
                    .Select(
                        e =>
                        new CompanyListItem
                        {
                            CompanyID = e.CompanyID,
                            CompanyName = e.CompanyName,
                            CompanyLocation = e.CompanyLocation
                        }
                        );
                return query.ToArray();
            }
        }
        ///add getcompanybyid method
        public CompanyDetail GetCompanyById(int CompanyID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Companies
                .Single(e => e.CompanyID == CompanyID);
                return
                    new CompanyDetail
                    {
                        CompanyID = entity.CompanyID,
                        CompanyLocation = entity.CompanyLocation,
                        CompanyName = entity.CompanyName
                    };
            }
        }

        public bool UpdateCompany(CompanyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Companies
                        .Single(e => e.CompanyID == model.CompanyID);

                entity.CompanyID = model.CompanyID;
                entity.CompanyName = model.CompanyName;
                entity.CompanyLocation = model.CompanyLocation;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCompany(int CompanyID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Companies
                        .Single(e => e.CompanyID == CompanyID);

                ctx.Companies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


        public List<Company> GetCompanyList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Companies.ToList();
            }
        }

    }
}
