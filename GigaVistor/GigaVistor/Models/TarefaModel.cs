namespace GigaVistor.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descricao { get; set; }
        public UsuarioModel responsavel { get; set; } = new UsuarioModel();
        public UsuarioModel Criador { get; set; } = new UsuarioModel();
        public SetorModel Setor { get; set; } = new SetorModel();
        public AuditoriaModel auditoria { get; set; } = new AuditoriaModel();
        public long Status { get; set; }
        public string Notas { get; set; }
        
    }
}
