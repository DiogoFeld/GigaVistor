using GigaVistor.Models;

namespace GigaVistor.Services.CheckListTemplateService
{
    public interface ICheckListTemplateServices
    {
        public bool AddTemplate(CheckListTemplateModel model);
        public bool GetAllTemplate(CheckListTemplateModel model);

    }
}
