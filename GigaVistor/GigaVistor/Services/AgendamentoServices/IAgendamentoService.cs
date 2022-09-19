using GigaVistor.Models;

namespace GigaVistor.Services.AgendamentoServices
{
    public interface IAgendamentoService
    {
        public IEnumerable<AgendamentoAuditoriaModel> getAllAuditorias();
        public void DeleteAAuditoria(int id);
    }
}
