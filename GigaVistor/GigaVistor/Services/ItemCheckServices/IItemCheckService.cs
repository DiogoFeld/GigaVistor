using GigaVistor.Models;

namespace GigaVistor.Services.ItemCheckServices
{
    public interface IItemCheckService
    {
        public bool addList(IEnumerable<ItemCheckModel> itens); 
        public bool addIten(ItemCheckModel item);
        public IEnumerable<ItemChecklistTemplateModel> GetItens();
        bool updateConformidade(ItemCheckModel conformidade);
    }
}
