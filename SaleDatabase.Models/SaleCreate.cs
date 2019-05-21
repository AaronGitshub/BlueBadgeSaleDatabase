using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleDatabase.Models
{
    public class SaleCreate
    {
        [Required]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Address { get; set; }
        [Display(Name = "Sale Price")]
        public decimal SalePrice { get; set; }
        [Display(Name = "SF")]
        public int SquareFootage { get; set; }

        public decimal PricePerSF { get; set; }

        [Display(Name = "Company ID")]
        public int CompanyID { get; set; }

    }
}
