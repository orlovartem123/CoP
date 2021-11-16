using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReznikovDatabase
{
    public class EducationForm
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
    }
}
