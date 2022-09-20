﻿using GigaVistor.Models;
using GigaVistor.Services.ProjetoServices;
using GigaVistor.Services.UsuarioServices;
using Microsoft.AspNetCore.Mvc;

namespace GigaVistor.Controllers
{
    public class ProjetoController : Controller
    {
        IProjetoService projeto;
        public ProjetoController(IProjetoService _projeto)
        {
            projeto = _projeto;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Index";
            return View(projeto.getAllProjetos());
        }


        public IActionResult Delete(int id)
        {
            projeto.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult EditPage(int id)
        {
            return View(projeto.EditPage(id));
        }

        public IActionResult Edit(ProjetoModel _projeto)
        {
            projeto.Edit(_projeto);
            return RedirectToAction("Index");
        }

        public IActionResult Create(ProjetoModel _projeto)
        {
            projeto.Create(_projeto);
            return RedirectToAction("Index");
        }

        public IActionResult CreatePage()
        {
            return View();
        }

        public IActionResult DeletePage(int id)
        {
            return View(projeto.DeletePage(id));
        }
    }
}
