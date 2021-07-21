using DA3.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DA3.Model.Models
{
    [Table("Slides")]
    public class Slide : Auditable
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        public string URL { get; set; }
        public int DisplayOrder { get; set; }
        public int SlideGroupID { get; set; }
        [ForeignKey("SlideGroupID")]
        public virtual SlideGroup SlideGroups { get; set; }
    }
}