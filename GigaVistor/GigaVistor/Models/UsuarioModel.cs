using System.ComponentModel.DataAnnotations;

namespace GigaVistor.Models
{
    public class UsuarioModel
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Logon { get; set; }
        [Required]
        public string Cargo { get; set; }
        [Required]
        public string Email { get; set; }
        public long IdSuperVisor { get; set; }
        public string Setor { get; set; }
        [Required]
        public int Permissao { get; set; }
    }
}
