using GigaVistor.Controllers.DatabaseSingleton;
using GigaVistor.Models;
using GigaVistor.Services.AuditoriaServices;
using GigaVistor.Services.ChecklistService;
using Microsoft.AspNetCore.Mvc;

namespace GigaVistor.Controllers
{
    public class ChecklistController : Controller
    {

        ICheckListService checkListService;
        public ChecklistController(ICheckListService _checkListService)
        {
            checkListService = _checkListService;
        }

        public IActionResult Create(long idAuditoria)
        {
            ViewBag.idAuditoria = idAuditoria;
            return View();
        }

        public IActionResult CreateAction(ChecklistModel model)
        {
            bool result = checkListService.CreateAction(model);
            if (result)
            {
                return RedirectToAction("Details", "Auditoria", new { id = (int)model.IdAuditoria });
            }
            else
            {
                return RedirectToAction("Create", new { id = (int)model.IdAuditoria });

            }
        }

        public IActionResult Details(int id)
        {
            ViewBag.Usuarios = checkListService.GetUsers();
            ViewBag.ItensCheckList = checkListService.getItensByCheckList(id);
            ChecklistModel model = checkListService.GetChecklist(id);       

            return View(model);
        }

        public IActionResult Check(int id)
        {
            ChecklistModel model = checkListService.GetChecklist(id);
            return View(model);
        }

    }
}
