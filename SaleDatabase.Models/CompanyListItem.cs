using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleDatabase.Models
{
    public class CompanyListItem
    {
        [Display(Name = "Company ID")]
        public int CompanyID { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Company Location")]
        public string CompanyLocation { get; set; }
    }
}
