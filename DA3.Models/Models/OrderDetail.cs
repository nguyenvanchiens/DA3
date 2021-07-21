using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DA3.Model.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {

        [Key, Column(Order = 0)]
        public int OrderID { get; set; }
        [Key, Column(Order = 1)]
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public virtual Order Orders { get; set; }
        public virtual Product Products { get; set; }
    }
}