using DA3.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DA3.Model.Models
{
    [Table("ProductCategories")]
    public class ProductCategory : Auditable
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Alias { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}