using GigaVistor.Models;

namespace GigaVistor.Services.SetorServices
{
    public interface ISetorService
    {
        public IEnumerable<SetorModel> getAllSetores();
        public void DeleteASetor(int id);
        public void EditAction(SetorModel setorModel);
        public SetorModel Edit(int id);
        public void CreateAction(SetorModel setorModel);

    }
}
