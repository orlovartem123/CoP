using System.Collections.Generic;

namespace ReznikovBusinessLogic
{
    public interface IEducationFormStorage
    {
        List<EducationFormViewModel> GetFullList();
        void Insert(EducationFormBindingModel model);
        void Delete(EducationFormBindingModel model);
        void Update(EducationFormBindingModel model);
        void Refill(List<EducationFormBindingModel> list);
        EducationFormViewModel GetElement(EducationFormBindingModel model);
    }
}
