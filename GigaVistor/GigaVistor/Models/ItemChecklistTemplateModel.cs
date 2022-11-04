namespace GigaVistor.Models
{
    public class ItemChecklistTemplateModel
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public long IdCheckList { get; set; }
             
        public DateTime DateCriacao { get; set; }
        public long IdCriador { get; set; }   


    }
}
