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
            ChecklistModel model = checkListService.GetChecklist(id);

            return View(model);
        }

        public IActionResult Check(int id)
        {
            ChecklistModel model = checkListService.GetChecklist(id);
            return View(model);
        }

        private bool EditChecklist(string name, string descrip)
        {
            bool result = false;

            return result;
        }

        public JsonResult AddNewItens(string descricoes,string responsaveis,string prazos,string escalonamentoResponsaveis)
        {
            int f = 9;

            return Json(new());
        }

    }
}
