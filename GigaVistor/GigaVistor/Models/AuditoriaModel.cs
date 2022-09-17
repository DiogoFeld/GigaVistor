namespace GigaVistor.Models
{
    public class AuditoriaModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Descricao { get; set; }
        public long IdCriador { get; set; }
        public DateTime AuditoriaDate { get; set; }
        public long IdProjeto { get; set; }
    }
}
