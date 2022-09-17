namespace GigaVistor.Models
{
    public class TemplateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long IdCriador { get; set; }
        public DateTime DateTime { get; set; }
    }
}
