using GigaVistor.Data;
using GigaVistor.Models;

namespace GigaVistor.Services.AuditoriaServices
{
    public class AuditoriaService : IAuditoriaService
    {

        GigaVistorContext db;
        public AuditoriaService(GigaVistorContext _db)
        {
            db = _db;
        }


        public void Create(AuditoriaModel _auditoria)
        {
            if (_auditoria.Id == 0)
            {
                AuditoriaModel auditoria = new AuditoriaModel();
                auditoria.Name = _auditoria.Name;
                auditoria.Descricao = _auditoria.Descricao;
                auditoria.IdCriador = _auditoria.IdCriador;
                auditoria.AuditoriaDate = _auditoria.AuditoriaDate;
                auditoria.IdProjeto = _auditoria.IdProjeto;


                db.Auditorias.Add(auditoria);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            AuditoriaModel auditoria = db.Auditorias.FirstOrDefault(s => s.Id == id);
            if (auditoria != null)
            {
                db.Remove(auditoria);
                db.SaveChanges();
            }            
        }

        public AuditoriaModel DeletePage(int id)
        {
            AuditoriaModel auditoria = db.Auditorias.FirstOrDefault(s => s.Id == id);                       
            return auditoria;

        }

        public void Edit(AuditoriaModel _auditoria)
        {
            if (_auditoria != null)
            {
                AuditoriaModel auditoria = db.Auditorias.FirstOrDefault(s => s.Id == _auditoria.Id);
                auditoria.Name = _auditoria.Name;
                auditoria.Descricao = _auditoria.Descricao;
                auditoria.IdCriador = _auditoria.IdCriador;
                auditoria.AuditoriaDate = _auditoria.AuditoriaDate;
                auditoria.IdProjeto = _auditoria.IdProjeto;

                db.SaveChanges();
            }
        }

        public AuditoriaModel EditPage(int id)
        {
            AuditoriaModel auditoria = db.Auditorias.FirstOrDefault(s => s.Id == id);
            return auditoria;            
        }

        public IEnumerable<AuditoriaModel> getAllAuditoria()
        {
            IEnumerable<AuditoriaModel> auditoria = db.Auditorias.Select(s => s).ToList();
            return auditoria;
            
        }
    }
}
