using ReznikovBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReznikovDatabase
{
    public class StudentStorage : IStudentStorage
    {
        public List<StudentViewModel> GetFullList()
        {
            using (var context = new DataBaseContext())
            {
                return context.Students
                .Select(CreateModel).ToList();
            }
        }

        public List<StudentViewModel> GetFilteredList(StudentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new DataBaseContext())
            {
                return context.Students
                    .Where(rec => rec.Id == model.Id)
                    .Select(CreateModel).ToList();
            }
        }

        public StudentViewModel GetElement(StudentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new DataBaseContext())
            {
                var student = context.Students
                .FirstOrDefault(rec => rec.Id == model.Id || rec.FIO == model.FIO);
                return student != null ?
                CreateModel(student) : null;
            }
        }

        public void Insert(StudentBindingModel model)
        {
            using (var context = new DataBaseContext())
            {
                CreateModel(model, new Student(), context);
                context.SaveChanges();
            }
        }

        public void Update(StudentBindingModel model)
        {
            using (var context = new DataBaseContext())
            {
                var element = context.Students.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Студент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
            }
        }

        public void Delete(StudentBindingModel model)
        {
            using (var context = new DataBaseContext())
            {
                Student element = context.Students.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Students.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Студент не найден");
                }
            }
        }

        private Student CreateModel(StudentBindingModel model, Student student, DataBaseContext context)
        {
            student.FIO = model.FIO;
            student.ReceiptDate = model.ReceiptDate;
            student.StudingForm = model.StudingForm;

            if (student.Id != 0)
            {
                
                List<AverageMark> marks = context.Students.FirstOrDefault(rec => rec.Id == student.Id).AverageMarks;
                context.AverageMarks.RemoveRange(marks);

                foreach (var pair in model.AverageMarks)
                {
                    AverageMark mark = new AverageMark
                    {
                        StudentId = student.Id,
                        Mark = pair.Value,
                        Period = pair.Key
                    };
                    context.AverageMarks.Add(mark);
                }
            }
            else
            {
                context.Students.Add(student);
                context.SaveChanges();
                foreach (var pair in model.AverageMarks)
                {
                    AverageMark mark = new AverageMark
                    {
                        StudentId = student.Id,
                        Mark = pair.Value,
                        Period = pair.Key
                    };
                    context.AverageMarks.Add(mark);
                }
            }

            return student;
        }

        private StudentViewModel CreateModel(Student student)
        {
            return new StudentViewModel
            {
                ReceiptDate = student.ReceiptDate,
                AverageMarks = student.AverageMarks.ToDictionary(rec=>rec.Period, rec=>rec.Mark),
                FIO = student.FIO,
                Id = student.Id,
                StudingForm = student.StudingForm
            };
        }
    }
}
