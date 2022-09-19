using GigaVistor.Models;

namespace GigaVistor.Services.UsuarioServices
{
    public interface IUsuarioService
    {
        public IEnumerable<UsuarioModel> getAllUsuarios();
        public void CreateAction(UsuarioModel usuario);
        public void DeleteAUsuario(int id);
        public UsuarioModel Edit(int id);
        public void EditAction(UsuarioModel setorModel);
        public UsuarioModel DeletePage(int id);
    }
}
