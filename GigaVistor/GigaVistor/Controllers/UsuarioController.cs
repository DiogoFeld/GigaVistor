using Microsoft.AspNetCore.Mvc;

namespace GigaVistor.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
