using GigaVistor.Models;

namespace GigaVistor.Services.ItemChecklistTemplateService
{
    public interface IItemChecklistTemplateService
    {
        public IEnumerable<ItemChecklistTemplateModel> getAll();
        public bool addList(IEnumerable<ItemChecklistTemplateModel> itens);
        public bool addIten(ItemChecklistTemplateModel item);
    }
}
