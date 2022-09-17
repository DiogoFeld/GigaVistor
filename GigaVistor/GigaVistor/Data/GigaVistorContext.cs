using GigaVistor.Models;
using Microsoft.EntityFrameworkCore;

namespace GigaVistor.Data
{
    public class GigaVistorContext : DbContext
    {
        public GigaVistorContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<SetorModel> Setores { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }


    }
}
