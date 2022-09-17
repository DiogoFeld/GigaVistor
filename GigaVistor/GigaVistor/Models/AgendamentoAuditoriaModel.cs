namespace GigaVistor.Models
{
    public class AgendamentoAuditoriaModel
    {
        public long Id{ get; set; }
        public string Name { get; set; }
        public long IdCriador{ get; set; }
        public long IdAuditoria { get; set; }
        public DateTime AuditoriaCriacao { get; set; }
        public DateTime AuditoriaDate { get; set; }
    }
}
