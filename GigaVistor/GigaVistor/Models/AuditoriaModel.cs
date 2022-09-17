namespace GigaVistor.Models
{
    public class AuditoriaModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Descricao { get; set; } 
        public UsuarioModel Criador { get; set; } = new UsuarioModel();
        public DateTime AuditoriaDate { get; set; }
        public ProjetoModel IdProjeto { get; set; } = new ProjetoModel();
    }
}
