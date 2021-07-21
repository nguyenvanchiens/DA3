using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA3.Models.Models
{
    [Table("VisitorStatics")]
    public class VisitorStatic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime VisitedDate { get; set; }
        public string IPAdderss { get; set; }
    }
}
