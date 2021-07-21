using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DA3.Model.Models
{
    [Table("FeedBacks")]
    public class FeedBack
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        public string Content { get; set; }

        [Required]
        public int IDProduct { get; set; }

        [ForeignKey("IDProduct")]
        public virtual Product Product { get; set; }

        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}