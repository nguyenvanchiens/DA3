using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DA3Angular.Models
{
    public class NewCategoryViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public bool ShowOnHome { get; set; }
        public string MetaTitle { get; set; }
        public int DisplayOrder { get; set; }
        public string SeoTitle { get; set; }
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescriptions { get; set; }

        public bool Status { get; set; }
        public virtual IEnumerable<NewsViewModel> News { get; set; }
    }
}