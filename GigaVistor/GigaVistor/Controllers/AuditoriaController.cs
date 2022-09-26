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
            return RedirectToAction("Index");
        }

        public IActionResult CreatePage()
        {
            return View();
        }

        public IActionResult DeletePage(int id)
        {
            return View(auditoria.DeletePage(id));
        } 

    }
}
