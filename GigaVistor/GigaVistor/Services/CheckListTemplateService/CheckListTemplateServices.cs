using GigaVistor.Data;
using GigaVistor.Models;
using GigaVistor.Services.CheckListTemplateService;

namespace GigaVistor.Services.CheckListTemplate
{
    public class CheckListTemplateServices : ICheckListTemplateServices
    {

        GigaVistorContext db;
        public CheckListTemplateServices(GigaVistorContext _db)
        {
            db = _db;
        }

        public bool AddTemplate(CheckListTemplateModel model)
        {
            try
            {
                if (model.Id == 0)
                {
                    db.checkListTemplates.Add(model);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<CheckListTemplateModel> GetAllTemplate()
        {
            IEnumerable<CheckListTemplateModel> templates = new List<CheckListTemplateModel>();
            try{
                templates = db.checkListTemplates.Select(s => s).ToList();
                return templates;
            }
            catch{
                return templates;
            }
        }

        public CheckListTemplateModel GetTemplate(int id)
        {
            CheckListTemplateModel model = new CheckListTemplateModel();
            model = db.checkListTemplates.FirstOrDefault(s => s.Id == id);

            return model;
        }

    }
}
