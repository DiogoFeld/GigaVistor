using GigaVistor.Controllers.DatabaseSingleton;
using GigaVistor.Data;
using GigaVistor.Models;
using System.Collections.Generic;
using System.Net.NetworkInformation;

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

        public bool SaveAuditoriaWithTemplate(AuditoriaModel auditoriaModel, List<CheckListTemplateModel> list)
        {
            //id template - idChecklist->not Template
            Dictionary<long, ChecklistModel> dictionaryTemplates = new Dictionary<long, ChecklistModel>();
            //id Template - ItensChecklist-> not Template
            Dictionary<long, List<ItemCheckModel>> dictionaryItens = new Dictionary<long, List<ItemCheckModel>>();
            int idAuditoria = 0;
            int idCheckList = 0;

            try
            {
                foreach (CheckListTemplateModel check in list)
                {
                    CheckListTemplateModel newTemplate = db.checkListTemplates.FirstOrDefault(s => s.Id == check.Id);
                    ChecklistModel newChecklist = new ChecklistModel()
                    {
                        Id = 0,
                        Status = 0,
                        Name = newTemplate.Descricao,
                        Descricao = "",
                    };
                    dictionaryTemplates.Add(newTemplate.Id, newChecklist);

                    //loadItens
                    List<ItemChecklistTemplateModel> itensTemplate = (from itens in db.itemCheckListTemplates
                                                                      where itens.IdCheckList == newTemplate.Id
                                                                      select itens).ToList();



                    List<ItemCheckModel> listItemCheckModel = new List<ItemCheckModel>();
                    foreach (ItemChecklistTemplateModel itemTemplateModel in itensTemplate)
                    {
                        ItemCheckModel itemCheckModel = new ItemCheckModel()
                        {
                            Id = 0,
                            Descricao = itemTemplateModel.Descricao,
                            Aderente = 0,
                            Status = 0,
                            Escalonado = false,
                            ExplicacaoNaoConformidade = "",
                            NaoConformidade = false,
                            NivelNaoConformidade = 0,
                            DateCriacao = DateTime.Now,
                            DatePrazo = DateTime.Now,
                            DatePrazoEscalonado = DateTime.Now,
                            StatusPosEscalonado = 0,
                            IdCriador = UserDatabase.Instance.getUsuario().Id,
                            IdResponsavel = 0,
                            IdCheckList = 0,
                            IdNaoConformidade = 0,
                            IdNaoConformidadeResponsavel = 0
                        };
                        listItemCheckModel.Add(itemCheckModel);
                    }
                    dictionaryItens.Add(newTemplate.Id, listItemCheckModel);
                }
                //get auditoria id.
                //get checklist id.
                //input itens on CheckList.

                //auditoria
                if (auditoriaModel.Id == 0)
                {
                    if (auditoriaModel.Name == null)
                        auditoriaModel.Name = "nulo";
                    if (auditoriaModel.Descricao == null)
                        auditoriaModel.Descricao = "nulo";

                    db.Auditorias.Add(auditoriaModel);
                    db.SaveChanges();

                    idAuditoria = (int)auditoriaModel.Id;
                }
                foreach (KeyValuePair<long, ChecklistModel> models in dictionaryTemplates)
                {
                    ChecklistModel checklistNew = models.Value;
                    checklistNew.IdAuditoria = idAuditoria;

                    db.checklists.Add(checklistNew);
                    db.SaveChanges();
                    idCheckList = checklistNew.Id;

                    foreach (ItemCheckModel item in dictionaryItens[models.Key])
                    {
                        ItemCheckModel itemNew = item;
                        itemNew.IdCheckList = idCheckList;

                        db.itensCheckList.Add(itemNew);
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Dictionary<long, int[]> getReportByAuditoria(int id)
        {
            Dictionary<long, int[]> results = new Dictionary<long, int[]>();
            try{
                List<ChecklistModel> checklistResult = new List<ChecklistModel>();
            
                checklistResult = (from checklist in db.checklists
                                   where checklist.IdAuditoria == id
                                   select checklist).ToList();

                foreach (ChecklistModel check in checklistResult)
                {

                    List<ItemCheckModel> itemlist = (from items in db.itensCheckList
                                                      where items.IdCheckList == check.Id
                                                      select items).ToList();

                    List<NaoConformidadeModel> naoConformidadeList = (from naoConformidades in db.naoConformidades
                                                         where naoConformidades.IdCheckList == check.Id
                                                         select naoConformidades).ToList();

                    int[] resultValue = new int[4];
                    //[0] - total De Tarefas
                    resultValue[0] = itemlist.Count;
                    //[1] - total De cumpridas
                    resultValue[1] = getDoneItens(itemlist);
                    //[2] - total de Nao Cumpridas
                    resultValue[2] = resultValue[0] - resultValue[1];
                    //[3] - total De n/Conformidades
                    resultValue[3] = naoConformidadeList.Count;

                    results.Add(check.Id, resultValue);
                }
            }
            catch { };

            return results;
        }

        private int getDoneItens(List<ItemCheckModel> itens)
        {
            int result = 0;
            foreach (ItemCheckModel item in itens)
            {
                if (item.Aderente == 1)
                {
                    result++;
                }
            }
            return result;
        }



    }
}
