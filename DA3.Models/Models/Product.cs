using DA3.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DA3.Model.Models
{
    [Table("Products")]
    public class Product : Auditable
    {

        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Alias { get; set; }
        [Required]
        public string Image { get; set; }
        public string MoreImage { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal? Promotion { get; set; }
        public int? Warranty { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int ProductCategoryID { get; set; }
        [ForeignKey("ProductCategoryID")]
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}