using GigaVistor.Models;

namespace GigaVistor.Services.TarefaServices
{
    public interface ITarefaService
    {
        public IEnumerable<TarefaModel> getAllTarefas();
        public IEnumerable<TarefaModel> getAllTarefasByAuditoria(int id);
        public void Create(TarefaModel tarefa);
        public void Delete(int id);
        public TarefaModel DeletePage(int id);
        public void Edit(TarefaModel tarefa);
        public TarefaModel EditPage(int id);
        public IEnumerable<SetorModel> getSetores();
        public IEnumerable<UsuarioModel> getFuncionarios();
    }
}
