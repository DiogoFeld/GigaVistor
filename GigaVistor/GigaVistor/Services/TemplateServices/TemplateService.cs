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

            IEnumerable<TemplateModel> templates = db.Templates.Select(s => s).ToList();
            return templates;
        }

        public IEnumerable<TarefaModel> getTarefasByAuditoria(int id)
        {

            var query = from tarefa in db.Tarefas
                        where tarefa.IdAuditoria == id
                        select tarefa;

            return query.ToList();
        }


        public bool CreateTemplateExport(List<TarefaTemplateModel> tarefas, TemplateModel template)
        {
            bool result = false;
            int idAuditoria = 0;


            if (template.Id == 0)
            {
                if (template.Name == null)
                    template.Name = "nulo";
                if (template.Description == null)
                    template.Description = "nulo";

                db.Templates.Add(template);
                db.SaveChanges();

                idAuditoria = template.Id;
            }

            foreach (TarefaTemplateModel tarefa in tarefas)
            {
                tarefa.IdAuditoria = idAuditoria;
                if (tarefa.Descricao == null)
                    tarefa.Descricao = "null";
                if (tarefa.Name == null)
                    tarefa.Name = "null";


                db.TarefasTemplate.Add(tarefa);
                db.SaveChanges();
            }

            return result;
        }

        public IEnumerable<TarefaTemplateModel> getAllTarefasByAuditoria(int id)
        {
            var query = from tarefa in db.TarefasTemplate
                        where tarefa.IdAuditoria == id
                        select tarefa;

            return query.ToList();
        }


    }
}
