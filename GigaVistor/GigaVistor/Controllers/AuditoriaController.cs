using Microsoft.AspNetCore.Mvc;

namespace GigaVistor.Controllers
{
    public class AuditoriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
