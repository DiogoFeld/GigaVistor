using GigaVistor.Data;
using GigaVistor.Models;
using GigaVistor.Services.AuditoriaServices;

namespace GigaVistor.Services.ChecklistService
{
    public class CheckListService : ICheckListService
    {
        GigaVistorContext db;
        public CheckListService(GigaVistorContext _db)
        {
            db = _db;
        }

        public bool CreateAction(ChecklistModel model)
        {
            try
            {
                if (model.Id == 0)
                {
                    db.checklists.Add(model);
                    db.SaveChanges();

                    if (model.Id != 0)
                        return true;
                }
            }
            catch { }
            return false;
        }

        public bool EditChecklist(string name, string descrip, int id)
        {
            return false;
            throw new NotImplementedException();
        }

        public ChecklistModel GetChecklist(int id)
        {
            ChecklistModel model = db.checklists.Find(id);

            return model;
        }


    }
}
