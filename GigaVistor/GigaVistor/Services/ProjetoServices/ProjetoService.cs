using GigaVistor.Data;
using GigaVistor.Models;

namespace GigaVistor.Services.ProjetoServices
{
    public class ProjetoService : IProjetoService
    {
        GigaVistorContext db;
        public ProjetoService(GigaVistorContext _db)
        {
            db = _db;
        }

        public void Create(ProjetoModel _projeto)
        {
            if (_projeto.Id == 0)
            {
                ProjetoModel projeto = new ProjetoModel();
                projeto.Name = _projeto.Name;
                projeto.IdCriador = _projeto.IdCriador;
                projeto.criacao = _projeto.criacao;
                projeto.status = _projeto.status;

                db.Projetos.Add(projeto);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            ProjetoModel projeto = db.Projetos.FirstOrDefault(s => s.Id == id);
            if (projeto != null)
            {
                db.Remove(projeto);
                db.SaveChanges();
            }
        }

        public ProjetoModel DeletePage(int id)
        {
            ProjetoModel projeto = db.Projetos.FirstOrDefault(s => s.Id == id);
            return projeto;
        }

        public void Edit(ProjetoModel _projeto)
        {
            if (_projeto != null)
            {
                ProjetoModel projeto = db.Projetos.FirstOrDefault(s => s.Id == _projeto.Id);
                projeto.Name = _projeto.Name;
                projeto.IdCriador = _projeto.IdCriador;
                projeto.criacao = _projeto.criacao;
                projeto.status = _projeto.status;

                db.SaveChanges();
            }
        }

        public ProjetoModel EditPage(int id)
        {
            ProjetoModel projeto = db.Projetos.FirstOrDefault(s => s.Id == id);
            return projeto;
        }

        public IEnumerable<ProjetoModel> getAllProjetos()
        {
            IEnumerable<ProjetoModel> projetos = db.Projetos.Select(s => s).ToList();
            return projetos;
        }


    }
}
