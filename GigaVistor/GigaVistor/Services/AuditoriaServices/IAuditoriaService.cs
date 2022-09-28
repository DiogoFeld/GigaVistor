using GigaVistor.Models;

namespace GigaVistor.Services.AuditoriaServices
{
    public interface IAuditoriaService
    {
        public IEnumerable<AuditoriaModel> getAllAuditoria();
        public void Create(AuditoriaModel auditoria);
        public void Delete(int id);
        public AuditoriaModel DeletePage(int id);
        public void Edit(AuditoriaModel auditoria);
        public AuditoriaModel EditPage(int id);
        public AuditoriaModel Details(int id);
        public UsuarioModel getCriadorId(long idCriador);
        public ProjetoModel getProjetoId(long idProjeto);
        public IEnumerable<TarefaModel> getTarefasByAuditoria(int id);
        public List<double> processAuditoria(IEnumerable<TarefaModel> tarefas);
    }
}
