using GigaVistor.Models;

namespace GigaVistor.Services.AgendamentoServices
{
    public interface IAgendamentoService
    {
        public IEnumerable<AgendamentoAuditoriaModel> getAllAgendamento();
        public void Create(AgendamentoAuditoriaModel agendamento);
        public void Delete(int id);
        public AgendamentoAuditoriaModel DeletePage(int id);
        public void Edit(AgendamentoAuditoriaModel agendamento);
        public AgendamentoAuditoriaModel EditPage(int id);
    }
}
