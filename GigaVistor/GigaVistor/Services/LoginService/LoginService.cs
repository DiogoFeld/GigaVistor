using GigaVistor.Data;
using GigaVistor.Models;

namespace GigaVistor.Services.LoginService
{
    public class LoginService : ILoginService
    {
        GigaVistorContext db;
        public LoginService(GigaVistorContext _db)
        {
            db = _db;
        }

        public bool LoginValidation(string logon, string email)
        {
            UsuarioModel usuario = db.Usuarios.FirstOrDefault(s => s.Logon == logon && s.Email == email);
            return (usuario != null);
        }

    }
}
