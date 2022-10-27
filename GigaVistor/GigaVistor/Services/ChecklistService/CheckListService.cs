using GigaVistor.Data;
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



    }
}
