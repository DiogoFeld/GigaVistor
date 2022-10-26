using GigaVistor.Controllers.DatabaseSingleton;
using GigaVistor.Models;
using GigaVistor.Services.AuditoriaServices;
using GigaVistor.Services.SetorServices;
using Microsoft.AspNetCore.Mvc;

namespace GigaVistor.Controllers
{
    public class AuditoriaController : Controller
    {
        IAuditoriaService auditoria;
        public AuditoriaController(IAuditoriaService _auditoria)
        {
            auditoria = _auditoria;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Index";
            return View(auditoria.getAllAuditoria());
        }

        public IActionResult Delete(int id)
        {
            auditoria.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult EditPage(int id)
        {
            return View(auditoria.EditPage(id));
        }

        public IActionResult Edit(AuditoriaModel _auditoria)
        {
            auditoria.Edit(_auditoria);
            return RedirectToAction("Index");
        }

        public IActionResult Create(AuditoriaModel _auditoria)
        {
            auditoria.Create(_auditoria);
            return RedirectToAction("Details", "Projeto", new { id = _auditoria.IdProjeto });
        }

        public IActionResult CreatePage(int id)
        {
            ViewBag.ProjetoId = id;
            ViewBag.IdAuditoria= id;
            return View();
        }

        public IActionResult DeletePage(int id)
        {
            return View(auditoria.DeletePage(id));
        }

        public IActionResult Details(int id)
        {
            AuditoriaModel auditoriaModel = auditoria.Details(id);
            ViewBag.Criador = auditoria.getCriadorId(auditoriaModel.IdCriador).Nome;
            ViewBag.Projeto = auditoria.getProjetoId(auditoriaModel.IdProjeto).Name;

            IEnumerable<TarefaModel> tarefas = auditoria.getTarefasByAuditoria(id);
            ViewBag.auditoriaResultado = auditoria.processAuditoria(tarefas);
            ViewBag.Tarefas = tarefas;

            return View(auditoriaModel);
        }

        public IActionResult ShowAuditoria(int id)
        {
            AuditoriaModel auditoriaModel = auditoria.Details(id);
            ViewBag.Usuarios = auditoria.getAllUsuarios();

            IEnumerable<TarefaModel> tarefas = auditoria.getTarefasByAuditoria(id);
            ViewBag.auditoriaResultado = auditoria.processAuditoria(tarefas);
            ViewBag.Tarefas = tarefas;

            return View(auditoriaModel);
        }
        public IActionResult CreatePageTemplate(int id)
        {
            ViewBag.idProjeto = id;
            ViewBag.Templates = auditoria.getAllTemplates();            
            return View();
        }


        public JsonResult CreateAuditoriaByTemplate(string nameAuditoria = "nulo", string idProjeto = "", string descricAuditoria = "nulo",
            string listNames = "", string listDescric = "", string listReponsavel = "", string listSetores = "")
        {
            AuditoriaModel auditoriaNew = new AuditoriaModel();
            auditoriaNew.IdProjeto = int.Parse(idProjeto);
            auditoriaNew.Name = nameAuditoria;
            auditoriaNew.Descricao = descricAuditoria;
            auditoriaNew.Id = 0;


            List<TarefaModel> tarefas = new List<TarefaModel>();
            string[] nomes = listNames.Split("//");
            string[] descricao = listDescric.Split("//");
            string[] responsaveis = listReponsavel.Split("//");
            string[] setores = listSetores.Split("//");

            for (int i = 0; i < nomes.Length; i++)
            {
                if (nomes[i] != "")
                {
                    TarefaModel tarefa = new TarefaModel();
                    tarefa.Name = nomes[i];
                    tarefa.Descricao = descricao[i];
                    tarefa.IdResponsavel = int.Parse(responsaveis[i]);
                    tarefa.IdSetor = int.Parse(setores[i]);

                    tarefas.Add(tarefa);
                }
            }

            auditoria.CreateAuditoriaByTemplate(auditoriaNew, tarefas);

            return Json(new());
        }

        public JsonResult SendEmail(string body, string idUser, string header)
        {
            int userId = int.Parse(idUser);
            string EmailTo = auditoria.getUsuarioById(userId).Email;

            var result = EmailController.Instance.SendEmail(body, EmailTo, header);
            return result;
        }


    }
}
