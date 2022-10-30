using GigaVistor.Models;

namespace GigaVistor.Services.ChecklistService
{
    public interface ICheckListService
    {
        public ChecklistModel GetChecklist(int id);
        public bool EditChecklist(string name, string descrip,int id);
        public bool CreateAction(ChecklistModel model);
        public IEnumerable<UsuarioModel> GetUsers();

    }
}
