using System;

namespace DA3.Model.Abstract
{
    public interface IAuditable
    {
        DateTime? CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        string ModifiedBy { get; set; }
        string MetaKeywords { get; set; }
        string MetaDescriptions { get; set; }
        bool Status { get; set; }
    }
}