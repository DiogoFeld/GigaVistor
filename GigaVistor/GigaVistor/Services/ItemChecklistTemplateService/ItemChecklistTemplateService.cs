using GigaVistor.Data;
using GigaVistor.Models;

namespace GigaVistor.Services.ItemChecklistTemplateService
{
    public class ItemChecklistTemplateService : IItemChecklistTemplateService
    {
        GigaVistorContext db;
        public ItemChecklistTemplateService(GigaVistorContext _db)
        {
            db = _db;
        }

        public IEnumerable<ItemChecklistTemplateModel> getAll()
        {
            IEnumerable<ItemChecklistTemplateModel> checklistTemplateItens = db.itemCheckListTemplates.Select(s => s).ToList();
            return checklistTemplateItens;
        }

        public bool addList(IEnumerable<ItemChecklistTemplateModel> itens)
        {
            try
            {
                foreach (ItemChecklistTemplateModel itemCheck in itens)
                {
                    db.itemCheckListTemplates.Add(itemCheck);
                }
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }


        public bool addIten(ItemChecklistTemplateModel item)
        {
            try
            {
                db.itemCheckListTemplates.Add(item);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }


    }
}
