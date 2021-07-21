using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DA3.Model.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerAdderss { get; set; }
        public string CustomerEmail { get; set; }
        [Required]
        public string CustomerPhone { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public bool Status { get; set; }
        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}