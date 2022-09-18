using Microsoft.AspNetCore.Mvc;

namespace GigaVistor.Controllers
{
    public class ProjetoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
