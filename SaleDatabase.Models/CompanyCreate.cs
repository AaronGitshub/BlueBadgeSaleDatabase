using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleDatabase.Models
{
    public class CompanyCreate
    {
        [Required]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Company Location")]
        public string CompanyLocation { get; set; }

    }
}
