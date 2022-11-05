using GigaVistor.Data;
using GigaVistor.Models;
using System.Drawing;

namespace GigaVistor.Services.ItemCheckServices
{
    public class ItemCheckService : IItemCheckService
    {
        GigaVistorContext db;
        public ItemCheckService(GigaVistorContext _db)
        {
            db = _db;
        }

        public IEnumerable<ItemChecklistTemplateModel> GetItens()
        {
            IEnumerable<ItemChecklistTemplateModel> checklistTemplateItens = db.itemCheckListTemplates.Select(s => s).ToList();
            return checklistTemplateItens;
        }

        public bool addList(IEnumerable<ItemCheckModel> itens)
        {
            try
            {
                foreach (ItemCheckModel itemCheck in itens)
                {
                    db.itensCheckList.Add(itemCheck);
                }
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }


        public bool addIten(ItemCheckModel item)
        {
            try{
                db.itensCheckList.Add(item);
                db.SaveChanges();
            }
            catch{
                return false;
            }
            return true;
        }


    }
}
