namespace GigaVistor.Models
{
    public class TarefaTemplateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descricao { get; set; }
        public UsuarioModel Criador { get; set; } = new UsuarioModel();
        public TemplateModel auditoria { get; set; } = new TemplateModel();       
        
    }
}
