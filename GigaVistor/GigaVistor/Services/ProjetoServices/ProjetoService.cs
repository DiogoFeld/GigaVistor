using GigaVistor.Data;
using GigaVistor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;
using System;

namespace GigaVistor.Services.ProjetoServices
{
    public class ProjetoService : IProjetoService
    {
        GigaVistorContext db;
        public ProjetoService(GigaVistorContext _db)
        {
            db = _db;
        }

        public void Create(ProjetoModel _projeto)
        {
            if (_projeto.Id == 0)
            {
                ProjetoModel projeto = new ProjetoModel();
                projeto.Name = _projeto.Name;
                projeto.IdCriador = _projeto.IdCriador;
                projeto.criacao = DateTime.Now;
                projeto.status = _projeto.status;

                db.Projetos.Add(projeto);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            ProjetoModel projeto = db.Projetos.FirstOrDefault(s => s.Id == id);
            if (projeto != null)
            {
                db.Remove(projeto);
                db.SaveChanges();
            }
        }

        public ProjetoModel DeletePage(int id)
        {
            ProjetoModel projeto = db.Projetos.FirstOrDefault(s => s.Id == id);
            return projeto;
        }

        public ProjetoModel Details(int id)
        {
            ProjetoModel projeto = db.Projetos.FirstOrDefault(s => s.Id == id);
            return projeto;
        }

        public void Edit(ProjetoModel _projeto)
        {
            if (_projeto != null)
            {
                ProjetoModel projeto = db.Projetos.FirstOrDefault(s => s.Id == _projeto.Id);
                projeto.Name = _projeto.Name;
                projeto.IdCriador = _projeto.IdCriador;
                projeto.criacao = _projeto.criacao;
                projeto.status = _projeto.status;

                db.SaveChanges();
            }
        }

        public ProjetoModel EditPage(int id)
        {
            ProjetoModel projeto = db.Projetos.FirstOrDefault(s => s.Id == id);
            return projeto;
        }

        public IEnumerable<ProjetoModel> getAllProjetos()
        {
            IEnumerable<ProjetoModel> projetos = db.Projetos.Select(s => s).ToList();
            return projetos;
        }

        public IEnumerable<AuditoriaModel> getAuditoriaByProject(long id)
        {
            var query = from auditorias in db.Auditorias
                        where auditorias.IdProjeto == id
                        select auditorias;

            return query.ToList();
        }

        public string getCriadorId(int idProjeto)
        {
            ProjetoModel projeto = db.Projetos.FirstOrDefault(s => s.Id == idProjeto);
            long idUser = projeto.IdCriador;
            string nameResult = db.Usuarios.FirstOrDefault(s => s.Id == idUser).Nome;

            return nameResult;
        }


        public Dictionary<long, int[]> getReport(int id)
        {
            Dictionary<long, int[]> results = new Dictionary<long, int[]>(); 
            try
            {                
                var query = from auditorias in db.Auditorias
                            where auditorias.IdProjeto == id
                            select auditorias;

                List<AuditoriaModel> auditoriasQ = query.ToList();

                foreach (AuditoriaModel auditoriaModel in auditoriasQ)
                {
                    List<ChecklistModel> checklistResult = new List<ChecklistModel>();

                    if (auditoriaModel.Id == 10005){
                        int hfewfewf = 8;
                    }

                    checklistResult = (from checklist in db.checklists
                                                       where checklist.IdAuditoria == auditoriaModel.Id
                                                       select checklist).ToList();



                    List<ItemCheckModel> itemResult = new List<ItemCheckModel>();
                    foreach (ChecklistModel check in checklistResult)
                    {
                        List<ItemCheckModel> itemlistQ = (from items in db.itensCheckList
                                                          where items.IdCheckList == check.Id
                                                          select items).ToList();

                        itemResult.AddRange(itemlistQ);
                    }
                    //nao Conformidades
                    List<NaoConformidadeModel> naoConformidadeResult = new List<NaoConformidadeModel>();
                    foreach (ChecklistModel check in checklistResult)
                    {
                        List<NaoConformidadeModel> checkQ = (from naoConformidades in db.naoConformidades
                                                             where naoConformidades.IdCheckList == check.Id
                                                             select naoConformidades).ToList();

                        naoConformidadeResult.AddRange(checkQ);
                    }
                    int[] resultValue = new int[4];
                    //[0] - total De Tarefas
                    resultValue[0] = itemResult.Count;
                    //[1] - total De cumpridas
                    resultValue[1] = getDoneItens(itemResult);
                    //[2] - total de Nao Cumpridas
                    resultValue[2] = resultValue[0] - resultValue[1];
                    //[3] - total De n/Conformidades
                    resultValue[3] = naoConformidadeResult.Count;                   

                    results.Add(auditoriaModel.Id, resultValue);
                }
            }
            catch { };

            return results;
        }



        private int getDoneItens(List<ItemCheckModel> itens)
        {
            int result = 0;
            foreach(ItemCheckModel item in itens)
            {
                if(item.Aderente == 1)
                {
                    result++;
                }
            }
            return result;
        }


    }
}
