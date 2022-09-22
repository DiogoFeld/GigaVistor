using GigaVistor.Data;
using GigaVistor.Models;

namespace GigaVistor.Services.TemplateServices
{
    public class TemplateService : ITemplateService
    {
        GigaVistorContext db;
        public TemplateService(GigaVistorContext _db)
        {
            db = _db;
        }

        public void Create(TemplateModel _template)
        {
            if (_template.Id == 0)
            {
                TemplateModel template = new TemplateModel();
                template.Name = _template.Name;
                template.Description = _template.Description;
                template.IdCriador = _template.IdCriador;
                template.DateTime = _template.DateTime;

                db.Templates.Add(template);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            TemplateModel template = db.Templates.FirstOrDefault(s => s.Id == id);
            if (template != null)
            {
                db.Remove(template);
                db.SaveChanges();
            }            
        }

        public TemplateModel DeletePage(int id)
        {
            TemplateModel template = db.Templates.FirstOrDefault(s => s.Id == id);
            return template;
        }

        public void Edit(TemplateModel _template)
        {
            if (_template != null)
            {
                TemplateModel template = db.Templates.FirstOrDefault(s => s.Id == _template.Id);
                template.Name = _template.Name;
                template.Description = _template.Description;
                template.IdCriador = _template.IdCriador;
                template.DateTime = _template.DateTime;                

                db.SaveChanges();
            }
        }
        public TemplateModel EditPage(int id)
        {
            TemplateModel template = db.Templates.FirstOrDefault(s => s.Id == id);
            return template;            
        }        
        public IEnumerable<TemplateModel> getAllTemplates()
        {

            IEnumerable<TemplateModel> templates= db.Templates.Select(s => s).ToList();
            return templates;
        }


    }
}
