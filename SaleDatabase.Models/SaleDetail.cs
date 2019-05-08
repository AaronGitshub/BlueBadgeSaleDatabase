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
        [Display(Name = "Created (UTC)")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified (UTC)")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
