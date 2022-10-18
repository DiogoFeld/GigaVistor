using GigaVistor.Models;
using GigaVistor.Services.AuditoriaServices;
using GigaVistor.Services.TarefaServices;
using Microsoft.AspNetCore.Mvc;

namespace GigaVistor.Controllers
{
    public class TarefaController : Controller
    {

        ITarefaService tarefa;
        public TarefaController(ITarefaService _tarefa)
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

        public IActionResult Edit(TarefaModel _tarefa)
        {
            tarefa.Edit(_tarefa);
            return RedirectToAction("Index");
        }

        public IActionResult Create(TarefaModel _tarefa)
        {
            tarefa.Create(_tarefa);         
            return RedirectToAction("Details", "Auditoria", new { id = _tarefa.IdAuditoria });
        }

        public IActionResult CreatePage(long id)
        {
            ViewBag.Funcionarios = tarefa.getFuncionarios();
            ViewBag.Setores = tarefa.getSetores();
            ViewBag.AuditoriaId = id;                      
            return View();
        }

        public IActionResult DeletePage(int id)
        {
            return View(tarefa.DeletePage(id));
        }


        public JsonResult getTarefa(int id)
        {
            IEnumerable<TarefaModel> tarefas = tarefa.getAllTarefasByAuditoria(id);
            return new JsonResult(tarefas);
        }


        public JsonResult updateTaskShow(string notes, int user, int status, int id)
        {
            TarefaModel newTarefa = new TarefaModel();
            newTarefa.Id = id;
            newTarefa.NotasQualidade = notes;
            newTarefa.IdResponsavel = user;
            newTarefa.Status = status;

            tarefa.EditTaskShow(newTarefa);            
            return Json(new());

        }


    }
}
