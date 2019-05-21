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
        [Display(Name = "Land Size")]
        public decimal LandSize { get; set; }
        [Display(Name = "Sq. Ft.")]
        public int SquareFootage { get; set; }
        [Display(Name = "Price Per SF")]
        public decimal PricePerSF
        {
            get
            {
                return SalePrice / SquareFootage;
            }
        }
        [Display(Name = "Buyer 1")]
        public string Buyer1 { get; set; }
        [Display(Name = "Buyer 2")]
        public string Buyer2 { get; set; }
        [Display(Name = "Seller 1")]
        public string Seller1 { get; set; }
        [Display(Name = "Seller 2")]
        public string Seller2 { get; set; }
        [Display(Name = "Created (UTC)")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified (UTC)")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        public virtual Company Company { get; set; }

        public int CompanyID { get; set; }

    }
}
