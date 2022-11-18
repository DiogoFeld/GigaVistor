using GigaVistor.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace GigaVistor.Services.NaoConformidadeService
{
    public interface INaoConformidadeService
    {
        public IEnumerable<NaoConformidadeModel> getAllNaoConformidades();
        public IEnumerable<NaoConformidadeModel> getConformidadesByTarefa(int idTarefa);
        ItemCheckModel getItemChecklist(int id);
        IEnumerable<UsuarioModel> GetUsers();
        bool updateNaoConformidade(NaoConformidadeModel naoConformidade);
    }
}
