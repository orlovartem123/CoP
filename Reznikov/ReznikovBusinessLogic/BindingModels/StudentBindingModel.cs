using System;
using System.Collections.Generic;

namespace ReznikovBusinessLogic
{
    public class StudentBindingModel
    {
        public int? Id { set; get; }
        public string FIO { set; get; }
        public Dictionary<string, float> AverageMarks { set; get; }
        public string EducationFormName { set; get; }
        public DateTime ReceiptDate { set; get; }
    }
}
