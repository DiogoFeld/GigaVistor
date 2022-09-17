namespace GigaVistor.Models
{
    public class AgendamentoAuditoriaModel
    {
        public long Id{ get; set; }
        public string Name { get; set; }
        public AuditoriaModel Auditoria { get; set; }  = new AuditoriaModel();
        public DateTime AuditoriaCriacao { get; set; }
        public DateTime AuditoriaDate { get; set; }
        public UsuarioModel Criador { get; set; } = new UsuarioModel();


    }
}
