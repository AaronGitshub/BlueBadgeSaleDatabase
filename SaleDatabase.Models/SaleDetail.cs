using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleDatabase.Models
{
    public class SaleDetail
    {
        [Display(Name = "Sale ID")]
        public int SaleID { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Sale Price")]
        public decimal SalePrice { get; set; }
        [Display(Name = "Sq. Ft.")]
        public int SquareFootage { get; set; }
        public decimal PricePerSF { get; set; }
        //public decimal PricePerSF
        //{
        //    get
        //    {
        //        return SalePrice / SquareFootage;
        //    }

        //}
        [Display(Name = "Buyer")]
        public string Buyer1 { get; set; }
        [Display(Name = "Seller")]
        public string Seller1 { get; set; }
        [Display(Name = "Company ID")]
        public int CompanyID { get; set; }
        [Display(Name = "Created (UTC)")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified (UTC)")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
