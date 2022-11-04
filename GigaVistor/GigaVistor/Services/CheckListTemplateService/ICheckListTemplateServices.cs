using GigaVistor.Models;

namespace GigaVistor.Services.CheckListTemplateService
{
    public interface ICheckListTemplateServices
    {
        public bool AddTemplate(CheckListTemplateModel model);
        public IEnumerable<CheckListTemplateModel> GetAllTemplate();
        public CheckListTemplateModel GetTemplate(int id);


    }
}
