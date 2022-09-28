using GigaVistor.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GigaVistor.Controllers.DatabaseSingleton
{
    public class UserDatabase
    {
        //singleton UserModel
        #region SINGLETON

        public UsuarioModel UsuarioModelActive;
        private static UserDatabase instance = null;
        
        private UserDatabase()
        {

        }

        public static UserDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDatabase();
                }
                return instance;
            }
        }

        #endregion
        public void CarregarUsuario(UsuarioModel _usuarioModel)
        {
            this.UsuarioModelActive = _usuarioModel;
        }


        public UsuarioModel getUsuario()
        {
            return this.UsuarioModelActive;
        }


    }
}
