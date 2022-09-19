using GigaVistor.Data;
using GigaVistor.Models;
using GigaVistor.Services.SetorServices;
using Microsoft.AspNetCore.Mvc;

namespace GigaVistor.Controllers
{
    public class SetorController : Controller
    {
        ISetorService setor;
        public SetorController(ISetorService _setor)
        {
            setor = _setor;
        }
               

        public IActionResult Index()
        {
            ViewData["Title"] = "Index";
            return View(setor.getAllSetores());
        }


        public IActionResult Delete(int id)
        {
            setor.DeleteASetor(id);
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            return View(setor.Edit(id));
        }

        public IActionResult EditAction(SetorModel _setor)
        {
            setor.EditAction(_setor);
            return RedirectToAction("Index");
        }

        public IActionResult CreateAction(SetorModel _setor)
        {
            setor.CreateAction(_setor);
            return RedirectToAction("Index");            
        }
        public IActionResult DeletePage(int id)
        {
            return View(setor.DeletePage(id));
        }

        public IActionResult Create()
        {
            return View();           
        }


    }
}
