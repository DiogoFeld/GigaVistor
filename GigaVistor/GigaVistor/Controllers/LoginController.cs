using GigaVistor.Services.LoginService;
using GigaVistor.Services.SetorServices;
using Microsoft.AspNetCore.Mvc;

namespace GigaVistor.Controllers
{
    public class LoginController : Controller
    {
        ILoginService login;
        public LoginController(ILoginService _login)
        {
            login = _login;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginValidation(string logon, string email)
        {
            if (true)
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return RedirectToAction("Login");
            }
        }




    }
}
