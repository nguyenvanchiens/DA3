using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DA3.Web.Models
{
    public class ProductCategoryViewModel
    {
        public int ID { get; set; }
       
        public string Name { get; set; }
      
        public string Alias { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescriptions { get; set; }
        public bool Status { get; set; }
        public virtual IEnumerable<ProductViewModel> Products { get; set; }
    }
}