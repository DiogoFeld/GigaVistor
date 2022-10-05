using GigaVistor.Models;

namespace GigaVistor.Services.TarefaTemplateServices
{
    public interface ITarefaTemplateService
    {
        public IEnumerable<TarefaTemplateModel> getAllTarefas();
        public IEnumerable<TarefaTemplateModel> getAllTarefasByAuditoria(int id);
        public void Create(TarefaTemplateModel tarefa);
        public void Delete(int id);
        public TarefaTemplateModel DeletePage(int id);
        public void Edit(TarefaTemplateModel tarefa);
        public TarefaTemplateModel EditPage(int id);
    }
}
