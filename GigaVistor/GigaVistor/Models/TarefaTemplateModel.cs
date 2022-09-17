namespace GigaVistor.Models
{
    public class TarefaTemplateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descricao { get; set; }
        public long IdSetor { get; set; } 
        public long IdCriador { get; set; }
        public long  IdAuditoria { get; set; }
        
    }
}
