using GigaVistor.Models;

namespace GigaVistor.Services.SetorServices
{
    public interface ISetorService
    {
        public IEnumerable<SetorModel> getAllSetores();
        public void CreateAction(SetorModel setorModel);
        public void DeleteASetor(int id);
        public SetorModel Edit(int id);
        public void EditAction(SetorModel setorModel);
        public SetorModel DeletePage(int id);

    }
}
