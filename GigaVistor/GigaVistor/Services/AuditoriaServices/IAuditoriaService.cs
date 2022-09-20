using GigaVistor.Models;

namespace GigaVistor.Services.AuditoriaServices
{
    public interface IAuditoriaService
    {
        public IEnumerable<AuditoriaModel> getAllAuditoria();
        public void Create(AuditoriaModel auditoria);
        public void Delete(int id);
        public AuditoriaModel DeletePage(int id);
        public void Edit(AuditoriaModel auditoria);
        public AuditoriaModel EditPage(int id);
    }
}
