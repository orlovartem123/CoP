using System.ComponentModel.DataAnnotations;

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
    }
}
