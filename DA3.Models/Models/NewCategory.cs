using DA3.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DA3.Model.Models
{
    [Table("NewCategories")]
    public class NewCategory : Auditable
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Alias { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public virtual IEnumerable<NewCategory> News { get; set; }
    }
}