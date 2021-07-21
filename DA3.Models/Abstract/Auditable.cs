using System;
using System.ComponentModel.DataAnnotations;

namespace DA3.Model.Abstract
{
    public abstract class Auditable : IAuditable
    {
        public DateTime? CreatedDate { get; set; }

        [MaxLength(256)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [MaxLength(256)]
        public string ModifiedBy { get; set; }

        [MaxLength(256)]
        public string MetaKeywords { get; set; }

        [MaxLength(256)]
        public string MetaDescriptions { get; set; }

        public bool Status { get; set; }
    }
}