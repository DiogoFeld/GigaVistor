using GigaVistor.Models;
using Microsoft.EntityFrameworkCore;

namespace GigaVistor.Data
{
    public class GigaVistorContext : DbContext
    {
        public DbSet<SetorModel> Setores { get; set; } = null!;
        public DbSet<UsuarioModel> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer( "Server=localhost;Initial Catalog=GigaVistor;Integrated Security=True");
        }
    }
}
