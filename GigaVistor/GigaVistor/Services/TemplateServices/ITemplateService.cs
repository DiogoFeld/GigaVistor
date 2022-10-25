using GigaVistor.Models;

namespace GigaVistor.Services.TemplateServices
{
    public interface ITemplateService
    {

        public IEnumerable<TemplateModel> getAllTemplates();
        public void Create(TemplateModel template);
        public void Delete(int id);
        public TemplateModel DeletePage(int id);
        public void Edit(TemplateModel template);
        public TemplateModel EditPage(int id);
        public IEnumerable<TarefaModel> getTarefasByAuditoria(int id);
        public bool CreateTemplateExport(List<TarefaTemplateModel> tarefas, TemplateModel template);
        public IEnumerable<TarefaTemplateModel> getAllTarefasByAuditoria(int id);        

    }
}
