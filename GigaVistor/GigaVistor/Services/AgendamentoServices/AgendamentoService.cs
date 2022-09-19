using GigaVistor.Data;
using GigaVistor.Models;

namespace GigaVistor.Services.AgendamentoServices
{
    public class AgendamentoService : IAgendamentoService
    {

        GigaVistorContext db;
        public AgendamentoService(GigaVistorContext _db)
        {
            db = _db;
        }

        public void DeleteAAuditoria(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AgendamentoAuditoriaModel> getAllAuditorias()
        {
            IEnumerable<AgendamentoAuditoriaModel> agendamentos = db.AgendamentosAuditoria.Select(s => s).ToList();
            return agendamentos;            
        }
    }
}
