using GigaVistor.Controllers.DatabaseSingleton;
using GigaVistor.Data;
using GigaVistor.Models;

namespace GigaVistor.Services.AuditoriaServices
{
    public class AuditoriaService : IAuditoriaService
    {

        GigaVistorContext db;
        public AuditoriaService(GigaVistorContext _db)
        {
            db = _db;
        }


        public void Create(AuditoriaModel _auditoria)
        {
            if (_auditoria.Id == 0)
            {
                AuditoriaModel auditoria = new AuditoriaModel();
                auditoria.Name = _auditoria.Name;
                auditoria.Descricao = _auditoria.Descricao;
                auditoria.IdCriador = UserDatabase.Instance.getUsuario().Id;
                auditoria.AuditoriaDate = DateTime.Now;
                auditoria.IdProjeto = _auditoria.IdProjeto;

                db.Auditorias.Add(auditoria);
                db.SaveChanges();
            }
        }


        public void Delete(int id)
        {
            AuditoriaModel auditoria = db.Auditorias.FirstOrDefault(s => s.Id == id);
            if (auditoria != null)
            {
                db.Remove(auditoria);
                db.SaveChanges();
            }
        }

        public AuditoriaModel DeletePage(int id)
        {
            AuditoriaModel auditoria = db.Auditorias.FirstOrDefault(s => s.Id == id);
            return auditoria;

        }

        public AuditoriaModel Details(int id)
        {
            AuditoriaModel auditoria = db.Auditorias.FirstOrDefault(s => s.Id == id);
            return auditoria;
        }

        public void Edit(AuditoriaModel _auditoria)
        {
            if (_auditoria != null)
            {
                AuditoriaModel auditoria = db.Auditorias.FirstOrDefault(s => s.Id == _auditoria.Id);
                auditoria.Name = _auditoria.Name;
                auditoria.Descricao = _auditoria.Descricao;
                auditoria.IdCriador = _auditoria.IdCriador;
                auditoria.AuditoriaDate = _auditoria.AuditoriaDate;
                auditoria.IdProjeto = _auditoria.IdProjeto;

                db.SaveChanges();
            }
        }

        public AuditoriaModel EditPage(int id)
        {
            AuditoriaModel auditoria = db.Auditorias.FirstOrDefault(s => s.Id == id);
            return auditoria;
        }

        public IEnumerable<AuditoriaModel> getAllAuditoria()
        {
            IEnumerable<AuditoriaModel> auditoria = db.Auditorias.Select(s => s).ToList();
            return auditoria;

        }

        public UsuarioModel getCriadorId(long idCriador)
        {
            UsuarioModel usuario = db.Usuarios.FirstOrDefault(s => s.Id == idCriador);
            return usuario;
        }

        public ProjetoModel getProjetoId(long idProjeto)
        {
            ProjetoModel projeto = db.Projetos.FirstOrDefault(s => s.Id == idProjeto);
            return projeto;
        }

        public IEnumerable<TarefaModel> getTarefasByAuditoria(int id)
        {

            var query = from tarefa in db.Tarefas
                        where tarefa.IdAuditoria == id
                        select tarefa;

            return query.ToList();
        }

        public List<double> processAuditoria(IEnumerable<TarefaModel> tarefas)
        {
            double total = tarefas.ToList().Count;
            int zerado = 0;
            int incompleto = 0;
            int completo = 0;
            foreach (TarefaModel tarefa in tarefas)
            {
                if (tarefa.Status == 0)
                {
                    zerado++;
                }
                if (tarefa.Status == 1)
                {
                    incompleto++;
                }
                if (tarefa.Status == 2)
                {
                    completo++;
                }
            }
            return new List<double>() { zerado, incompleto, completo };
        }


    }
}
