using GigaVistor.Data;
using GigaVistor.Models;
using Microsoft.AspNetCore.Mvc;

namespace GigaVistor.Controllers
{
    public class SetorController : Controller
    {

        GigaVistorContext context;
        public SetorController(GigaVistorContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            IEnumerable<SetorModel> setores = context.Setores.Select(s => s).ToList();
            return View(setores);            
        }


    }
}
