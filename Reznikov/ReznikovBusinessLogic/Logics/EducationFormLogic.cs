using System;
using System.Collections.Generic;

namespace ReznikovBusinessLogic
{
    public class EducationFormLogic
    {
        private readonly IEducationFormStorage _EducationFormStorage;
        public void ReFill(List<EducationFormBindingModel> list) {
            _EducationFormStorage.Refill(list);
        }
        public EducationFormLogic(IEducationFormStorage EducationFormStorage)
        {
            _EducationFormStorage = EducationFormStorage;
        }
        public List<EducationFormViewModel> Read(EducationFormBindingModel model)
        {
            if (model == null)
            {
                return _EducationFormStorage.GetFullList();
            }
            return new List<EducationFormViewModel> { _EducationFormStorage.GetElement(model) };
        }
        public void CreateOrUpdate(EducationFormBindingModel model)
        {
            var element = _EducationFormStorage.GetElement(new EducationFormBindingModel
            {
                Name = model.Name
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Такое направление уже существует");
            }
            if (model.Id.HasValue)
            {
                _EducationFormStorage.Update(model);
            }
            else
            {
                _EducationFormStorage.Insert(model);
            }
        }
        public void Delete(EducationFormBindingModel model)
        {
            var element = _EducationFormStorage.GetElement(new EducationFormBindingModel
            {
                Id = model.Id,
                Name = model.Name
            });
            if (element == null)
            {
                throw new Exception("Направление не найдено");
            }
            _EducationFormStorage.Delete(model);
        }

    }
}
