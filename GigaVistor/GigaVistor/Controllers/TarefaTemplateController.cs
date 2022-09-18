using Microsoft.AspNetCore.Mvc;

namespace GigaVistor.Controllers
{
    public class TarefaTemplateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
