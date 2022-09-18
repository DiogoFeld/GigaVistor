using Microsoft.AspNetCore.Mvc;

namespace GigaVistor.Controllers
{
    public class TarefaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
