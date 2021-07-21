using DA3.Model.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DA3.Model.Models
{
    [Table("News")]
    public class News : Auditable
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Alias { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Description { get; set; }
        public string Content { get; set; }
        public int NewCategoryID { get; set; }
        [ForeignKey("NewCategoryID")]
        public virtual NewCategory NewCategories { get; set; }
    }
}