namespace GigaVistor.Models
{
    public class TemplateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public UsuarioModel Criador { get; set; } = new UsuarioModel();
        public DateTime DateTime { get; set; }
        public List<TarefaTemplateModel> tarefas { get; set; } = new List<TarefaTemplateModel>();
    }
}
