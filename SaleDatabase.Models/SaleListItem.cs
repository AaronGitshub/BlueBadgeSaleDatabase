using SaleDatabase.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleDatabase.Models
{
    public class SaleListItem
    {
        [Display(Name = "Sale ID")]
        public int SaleID { get; set; }
        public string Address { get; set; }
        [Display(Name = "Sale Price")]
        public decimal SalePrice { get; set; }
        [Display(Name = "Price Per SF")]
        public decimal PricePerSF { get; set; }
        [Display(Name = "Company ID")]
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
