using GigaVistor.Controllers.DatabaseSingleton;
using GigaVistor.Models;
using GigaVistor.Services.CheckListTemplateService;
using GigaVistor.Services.ProjetoServices;
using Microsoft.AspNetCore.Mvc;

namespace GigaVistor.Controllers
{
    public class CheckListTemplateController : Controller
    {
        ICheckListTemplateServices template;
        public CheckListTemplateController(ICheckListTemplateServices _template)
        {
            template = _template;
        }


        public IActionResult CreateAction(CheckListTemplateModel newTemplate)
        {
            newTemplate.IdCriador = UserDatabase.Instance.getUsuario().Id;
            template.AddTemplate(newTemplate);       

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            ViewBag.itens = template.GetItensOfChecklist(id);
            CheckListTemplateModel model = template.GetTemplate(id);

            return View(model);
        }

        public IActionResult Create(TarefaModel _tarefa)
        {            
            return View();
        }

        public IActionResult Index()
        {
            IEnumerable<CheckListTemplateModel> templates = template.GetAllTemplate();
            return View(templates);            
        }

        public JsonResult getChecklistItens(string idCheckList)
        {
            int check = int.Parse(idCheckList);

            IEnumerable<ItemChecklistTemplateModel> itens = template.GetItensOfChecklist(check);

            return Json(itens);
        }


    }
}
