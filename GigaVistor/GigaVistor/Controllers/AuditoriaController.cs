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

    }
}
