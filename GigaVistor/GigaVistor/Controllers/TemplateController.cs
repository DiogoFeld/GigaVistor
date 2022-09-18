using Microsoft.AspNetCore.Mvc;

namespace GigaVistor.Controllers
{
    public class TemplateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
