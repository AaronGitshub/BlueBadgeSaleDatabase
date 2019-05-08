using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleDatabase.Models
{
    public class SaleEdit
    {
        [Display(Name = "Sale ID")]
        public int SaleID { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Sale Price")]
        public decimal SalePrice { get; set; }
    }
}
