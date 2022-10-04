using GigaVistor.Models;
using GigaVistor.Services.TarefaTemplateServices;
using GigaVistor.Services.TemplateServices;
using Microsoft.AspNetCore.Mvc;

namespace GigaVistor.Controllers
{
    public class TemplateController : Controller
    {
        ITemplateService template;
        public TemplateController(ITemplateService _template)
        {
            template = _template;
        }


        public IActionResult Index()
        {
            ViewData["Title"] = "Index";
            return View(template.getAllTemplates());
        }

        public IActionResult Delete(int id)
        {
            template.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult EditPage(int id)
        {
            return View(template.EditPage(id));
        }

        public IActionResult Edit(TemplateModel _template)
        {
            template.Edit(_template);
            return RedirectToAction("Index");
        }

        public IActionResult Create(TemplateModel _template)
        {
            template.Create(_template);
            return RedirectToAction("Index");
        }

        public IActionResult CreatePage()
        {
            return View();
        }

        public IActionResult DeletePage(int id)
        {
            return View(template.DeletePage(id));
        }



        public JsonResult getTemplates()
        {
            IEnumerable<TemplateModel> templates = template.getAllTemplates();
            return new JsonResult(templates);
        }


    }
}
