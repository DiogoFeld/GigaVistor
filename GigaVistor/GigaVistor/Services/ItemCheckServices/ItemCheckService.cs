using GigaVistor.Data;
using GigaVistor.Models;

namespace GigaVistor.Services.ItemCheckServices
{
    public class ItemCheckService : IItemCheckService
    {
        GigaVistorContext db;
        public ItemCheckService(GigaVistorContext _db)
        {
            db = _db;
        }
        public bool addNewIten(IEnumerable<ItemCheckModel> itens)
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






    }
}
