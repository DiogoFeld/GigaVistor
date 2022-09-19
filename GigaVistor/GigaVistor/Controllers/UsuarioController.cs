using GigaVistor.Models;
using GigaVistor.Services.SetorServices;
using GigaVistor.Services.UsuarioServices;
using Microsoft.AspNetCore.Mvc;

namespace GigaVistor.Controllers
{
    public class UsuarioController : Controller
    {

        IUsuarioService usuario;
        public UsuarioController(IUsuarioService _usuario)
        {
            usuario = _usuario;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Index";
            return View(usuario.getAllUsuarios());
        }


        public IActionResult Delete(int id)
        {
            usuario.DeleteAUsuario(id);
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            return View(usuario.Edit(id));
        }

        public IActionResult EditAction(UsuarioModel _usuario)
        {
            usuario.EditAction(_usuario);
            return RedirectToAction("Index");
        }

        public IActionResult CreateAction(UsuarioModel _usuario)
        {
            usuario.CreateAction(_usuario);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult DeletePage(int id)
        {
            return View(usuario.DeletePage(id));
        }


    }
}
