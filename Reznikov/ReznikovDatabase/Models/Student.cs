using ReznikovBusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReznikovDatabase
{
    public class Student
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string FIO { set; get; }
        [Required]
        public string EducationFormName { set; get; }
        [Required]
        public DateTime ReceiptDate { set; get; }
        [ForeignKey("StudentId")]
        public virtual List<AverageMark> AverageMarks { set; get; }
    }
}
