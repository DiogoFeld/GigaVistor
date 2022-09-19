using GigaVistor.Data;
using GigaVistor.Models;

namespace GigaVistor.Services.SetorServices
{
    public class SetorService : ISetorService
    {
        GigaVistorContext db;
        public SetorService(GigaVistorContext _db)
        {
            db = _db;
        }

        public void CreateAction(SetorModel _setorModel)
        {
            if (_setorModel.Id == 0)
            {
                SetorModel setor = new SetorModel();
                setor.SupervisorId = _setorModel.SupervisorId;
                setor.Nome = _setorModel.Nome;

                db.Setores.Add(setor);
                db.SaveChanges();
            }
        }

        public void DeleteASetor(int id)
        {
            SetorModel setor = db.Setores.FirstOrDefault(s => s.Id == id);
            if (setor != null)
            {
                db.Remove(setor);
                db.SaveChanges();
            }
        }

        public SetorModel DeletePage(int id)
        {
            SetorModel setor = db.Setores.FirstOrDefault(s => s.Id == id);
            return setor;
        }

        public SetorModel Edit(int id)
        {
            SetorModel setor = db.Setores.FirstOrDefault(s => s.Id == id);
            return setor;
        }

        public void EditAction(SetorModel _setor)
        {
            if (_setor != null)
            {
                SetorModel setor = db.Setores.FirstOrDefault(s => s.Id == _setor.Id);
                setor.Nome = _setor.Nome;
                setor.SupervisorId = _setor.SupervisorId;
                db.SaveChanges();
            }
        }

        public IEnumerable<SetorModel> getAllSetores()
        {
            IEnumerable<SetorModel> setores = db.Setores.Select(s => s).ToList();
            return setores;
        }


    }
}
