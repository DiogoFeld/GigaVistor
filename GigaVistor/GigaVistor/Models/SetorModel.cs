using System.ComponentModel.DataAnnotations;

namespace GigaVistor.Models
{
    public class SetorModel
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Nome { get; set; }
        public long SupervisorId { get; set; }       


    }
}
