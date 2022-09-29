using GigaVistor.Controllers.DatabaseSingleton;
using GigaVistor.Models;
using GigaVistor.Services.AgendamentoServices;
using GigaVistor.Services.AuditoriaServices;
using Microsoft.AspNetCore.Mvc;

namespace GigaVistor.Controllers
{
    public class AgendamentoController : Controller
    {
        IAgendamentoService agendamento;
        public AgendamentoController(IAgendamentoService _agendamento)
        {
            agendamento = _agendamento;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Index";
            return View(agendamento.getAllAgendamento());
        }

        public IActionResult Delete(int id)
        {
            agendamento.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult EditPage(int id)
        {
            return View(agendamento.EditPage(id));
        }

        public IActionResult Edit(AgendamentoAuditoriaModel _agendamento)
        {
            agendamento.Edit(_agendamento);
            return RedirectToAction("Index");
        }

        public IActionResult Create(AgendamentoAuditoriaModel _agendamento)
        {
            agendamento.Create(_agendamento);
            return RedirectToAction("Index");
        }

        public IActionResult CreatePage()
        {
            ViewBag.IdAutor = UserDatabase.Instance.getUsuario();
            return View();
        }

        public IActionResult DeletePage(int id)
        {
            return View(agendamento.DeletePage(id));
        }


    }
}
