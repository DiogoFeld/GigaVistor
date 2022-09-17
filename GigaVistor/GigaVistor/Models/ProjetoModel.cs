using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection.Metadata.Ecma335;

namespace GigaVistor.Models
{
    public class ProjetoModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public UsuarioModel Criador { get; set; } = new UsuarioModel();
        public DateTime criacao { get; set; }
        public long status { get; set; }

    }
}
