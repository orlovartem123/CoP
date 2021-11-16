using ReznikovBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReznikovDatabase
{
    public class EducationFormStorage : IEducationFormStorage
    {
        public List<EducationFormViewModel> GetFullList()
        {
            using (var context = new DataBaseContext())
            {
                return context.EducationForms
                .Select(CreateModel).ToList();
            }
        }

        public EducationFormViewModel GetElement(EducationFormBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new DataBaseContext())
            {
                var EducationForm = context.EducationForms
                .FirstOrDefault(rec => rec.Id == model.Id || rec.Name == model.Name);
                return EducationForm != null ?
                CreateModel(EducationForm) : null;
            }
        }

        public void Insert(EducationFormBindingModel model)
        {
            using (var context = new DataBaseContext())
            {
                context.EducationForms.Add(CreateModel(model, new EducationForm()));
                context.SaveChanges();
            }
        }

        public void Update(EducationFormBindingModel model)
        {
            using (var context = new DataBaseContext())
            {
                var element = context.EducationForms.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("форма обучения не найдена");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(EducationFormBindingModel model)
        {
            using (var context = new DataBaseContext())
            {
                EducationForm element = context.EducationForms.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.EducationForms.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("форма обучения не найдена");
                }
            }
        }

        private EducationForm CreateModel(EducationFormBindingModel model, EducationForm EducationForm)
        {
            EducationForm.Name = model.Name;
            return EducationForm;
        }

        private EducationFormViewModel CreateModel(EducationForm EducationForm)
        {
            return new EducationFormViewModel
            {
                Id = EducationForm.Id,
                Name = EducationForm.Name,
            };
        }

        public void Refill(List<EducationFormBindingModel> list)
        {
            using (var context = new DataBaseContext())
            {
                List<EducationForm> curList = context.EducationForms.ToList();

                foreach (var edu in curList)
                {
                    context.EducationForms.Remove(edu);
                }
                foreach (var edu in list)
                {
                    context.EducationForms.Add(new EducationForm
                    {
                        Name = edu.Name
                    });
                }
                context.SaveChanges();
            }
        }
    }
}
