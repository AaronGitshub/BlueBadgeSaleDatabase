using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleDatabase.Data
{
    public class Sale
    {
        [Key]
        public int SaleID { get; set; }
        
        public Guid OwnerID { get; set; }
        
        [Display(Name = "Sale Type")]
        public string SaleType { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Sale Price")]
        public decimal SalePrice { get; set; }
        
        public decimal LandSize { get; set; }
        
        public int SquareFootage { get; set; }
        
        public string Buyer1 { get; set; }
        public string Buyer2 { get; set; }
        
        public string Seller1 { get; set; }
        public string Seller2 { get; set; }
        
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        public virtual Company Company {get; set; }

}
}
