using GigaVistor.Controllers.DatabaseSingleton;
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

        public IActionResult CreatePageTemplate(int id)
        {
            //auditoriaID
            IEnumerable<TarefaModel> tarefas = template.getTarefasByAuditoria(id);
            ViewBag.Tarefas = tarefas;

            return View();
        }

        public JsonResult CreateTemplateExport(string nome, string descricao, string listNames, string listDescription)
        {
            string[] listNameArray = listNames.Split("//");
            string[] listDescriptionArray = listDescription.Split("//");
            List<TarefaTemplateModel> listTarefas = new List<TarefaTemplateModel>();
            long idUser = UserDatabase.Instance.getUsuario().Id;

            for (int i = 0; i < listDescriptionArray.Length; i++)
            {
                if (listDescriptionArray[i] != "")
                {
                    TarefaTemplateModel newTarefa = new TarefaTemplateModel();
                    newTarefa.Descricao = listDescriptionArray[i];
                    newTarefa.Name = listNameArray[i];
                    newTarefa.IdSetor = 0;
                    newTarefa.IdCriador = idUser;

                    listTarefas.Add(newTarefa);
                }
            }

            TemplateModel templateModel = new TemplateModel();
            templateModel.Name = nome;
            templateModel.Description = descricao;
            templateModel.IdCriador = idUser;
            templateModel.DateTime = DateTime.Now;

            template.CreateTemplateExport(listTarefas, templateModel);

            var result = new JsonResult("Sucess");
            return result;
        }
    }
}
