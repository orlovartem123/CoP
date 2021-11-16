using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReznikovDatabase
{
    public class AverageMark
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string Period { set; get; }
        [Required]
        public float Mark { set; get; }
        public int StudentId { set; get; }
        public virtual Student Student {set;get;}
    }
}
