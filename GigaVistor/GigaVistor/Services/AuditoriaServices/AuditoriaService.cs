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

        public IEnumerable<UsuarioModel> getAllUsuarios()
        {
            IEnumerable<UsuarioModel> Usuarios = db.Usuarios.Select(s => s).ToList();
            return Usuarios;
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

        public IEnumerable<ChecklistModel> getCheckListsByAuditoria(int id)
        {

            var query = from checklist in db.checklists
                        where checklist.IdAuditoria == id
                        select checklist;

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

        public IEnumerable<TemplateModel> getAllTemplates()
        {
            IEnumerable<TemplateModel> templates = db.Templates.Select(s => s).ToList();
            return templates;
        }

        public bool CreateAuditoriaByTemplate(AuditoriaModel auditoriaModel, List<TarefaModel> tarefas)
        {
            bool result = false;
            int idAuditoria = 0;

            if (auditoriaModel.Id == 0)
            {
                if (auditoriaModel.Name == null)
                    auditoriaModel.Name = "nulo";
                if (auditoriaModel.Descricao == null)
                    auditoriaModel.Descricao = "nulo";

                auditoriaModel.AuditoriaDate = DateTime.Now;
                auditoriaModel.IdCriador = UserDatabase.Instance.getUsuario().Id;

                db.Auditorias.Add(auditoriaModel);
                db.SaveChanges();

                idAuditoria = (int)auditoriaModel.Id;

                foreach (TarefaModel tarefa in tarefas)
                {
                    tarefa.IdAuditoria = idAuditoria;
                    if (tarefa.Descricao == null)
                        tarefa.Descricao = "null";
                    if (tarefa.Name == null)
                        tarefa.Name = "null";

                    tarefa.IdCriador = UserDatabase.Instance.getUsuario().Id;
                    tarefa.IdAuditoria = idAuditoria;
                    tarefa.Status = 0;
                    tarefa.NotasQualidade = "";

                    db.Tarefas.Add(tarefa);
                    db.SaveChanges();

                    result = true;
                }
            }
            return result;
        }

        public UsuarioModel getUsuarioById(int id)
        {
            UsuarioModel usuario = db.Usuarios.FirstOrDefault(s => s.Id == id);
            
            return usuario;
        }

        public IEnumerable<CheckListTemplateModel> getTemplatesCheckList()
        {
            IEnumerable<CheckListTemplateModel> templates = new List<CheckListTemplateModel>();
            try
            {
                templates = db.checkListTemplates.Select(s => s).ToList();
                return templates;
            }
            catch
            {
                return templates;
            }
        }
    }
}
