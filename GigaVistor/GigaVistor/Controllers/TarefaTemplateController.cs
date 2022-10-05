using GigaVistor.Models;
using GigaVistor.Services.TarefaServices;
using GigaVistor.Services.TarefaTemplateServices;
using Microsoft.AspNetCore.Mvc;

namespace GigaVistor.Controllers
{
    public class TarefaTemplateController : Controller
    {
        ITarefaTemplateService tarefa;
        public TarefaTemplateController(ITarefaTemplateService _tarefa)
        {
            tarefa = _tarefa;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Index";
            return View(tarefa.getAllTarefas());
        }

        public IActionResult Delete(int id)
        {
            tarefa.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult EditPage(int id)
        {
            return View(tarefa.EditPage(id));
        }

        public IActionResult Edit(TarefaTemplateModel _tarefa)
        {
            tarefa.Edit(_tarefa);
            return RedirectToAction("Index");
        }

        public IActionResult Create(TarefaTemplateModel _tarefa)
        {
            tarefa.Create(_tarefa);
            return RedirectToAction("Index");
        }

        public IActionResult CreatePage()
        {
            return View();
        }

        public IActionResult DeletePage(int id)
        {
            return View(tarefa.DeletePage(id));
        }

        public JsonResult getTarefa(int id)
        {
            IEnumerable<TarefaTemplateModel> tarefas = tarefa.getAllTarefasByAuditoria(id);
            return new JsonResult(tarefas);
        }
    }
}
