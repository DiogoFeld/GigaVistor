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

        public void Create(AgendamentoAuditoriaModel _agendamento)
        {
            if (_agendamento.Id == 0)
            {
                AgendamentoAuditoriaModel agendamento = new AgendamentoAuditoriaModel();
                agendamento.Name = _agendamento.Name;
                agendamento.IdCriador = _agendamento.IdCriador;
                agendamento.IdAuditoria = _agendamento.IdAuditoria;
                agendamento.AuditoriaCriacao = _agendamento.AuditoriaCriacao;
                agendamento.AuditoriaDate = _agendamento.AuditoriaDate;

                db.AgendamentosAuditoria.Add(agendamento);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            AgendamentoAuditoriaModel agendamento = db.AgendamentosAuditoria.FirstOrDefault(s => s.Id == id);
            if (agendamento != null)
            {
                db.Remove(agendamento);
                db.SaveChanges();
            }
        }

        public AgendamentoAuditoriaModel DeletePage(int id)
        {
            AgendamentoAuditoriaModel agendamento = db.AgendamentosAuditoria.FirstOrDefault(s => s.Id == id);
            return agendamento;
        }

        public void Edit(AgendamentoAuditoriaModel _agendamento)
        {
            if(_agendamento != null)
            {
                AgendamentoAuditoriaModel agendamento = 
                    db.AgendamentosAuditoria.FirstOrDefault(s => s.Id == _agendamento.Id);
                agendamento.Name = _agendamento.Name;
                agendamento.IdCriador = _agendamento.IdCriador;
                agendamento.IdAuditoria = _agendamento.IdAuditoria;
                agendamento.AuditoriaCriacao = _agendamento.AuditoriaCriacao;
                agendamento.AuditoriaDate = _agendamento.AuditoriaDate;
            
                db.SaveChanges();
            }
        }

        public AgendamentoAuditoriaModel EditPage(int id)
        {
            AgendamentoAuditoriaModel agendamento = db.AgendamentosAuditoria.FirstOrDefault(s => s.Id == id);
            return agendamento;            
        }

        public IEnumerable<AgendamentoAuditoriaModel> getAllAgendamento()
        {
            IEnumerable<AgendamentoAuditoriaModel> agendamentos = db.AgendamentosAuditoria.Select(s => s).ToList();
            return agendamentos;            
        }

    }
}
