namespace GigaVistor.Models
{
    public class ChecklistModel
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public string Descricao { get; set; }
        public long IdAuditoria { get; set; }
    }
}
