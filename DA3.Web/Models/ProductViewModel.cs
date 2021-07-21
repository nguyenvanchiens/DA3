using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA3.Web.Models
{
    public class ProductViewModel
    {
      
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Image { get; set; }
        public string MoreImage { get; set; }
        public decimal Price { get; set; }
        public decimal? Promotion { get; set; }
        public int Quantity { get; set; }
        public int? Warranty { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int ProductCategoryID { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescriptions { get; set; }

        public bool Status { get; set; }
        public virtual ProductCategoryViewModel ProductCategory { get; set; }
    }
}