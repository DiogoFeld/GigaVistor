using GigaVistor.Models;
using GigaVistor.Services.ItemChecklistTemplateService;
using Microsoft.EntityFrameworkCore;

namespace GigaVistor.Data
{
    public class GigaVistorContext : DbContext
    {
        public GigaVistorContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AgendamentoAuditoriaModel> AgendamentosAuditoria { get; set; }
        public DbSet<AuditoriaModel> Auditorias { get; set; }
        public DbSet<ProjetoModel> Projetos { get; set; }
        public DbSet<SetorModel> Setores { get; set; }
        public DbSet<TarefaModel> Tarefas{ get; set; }
        public DbSet<TarefaTemplateModel> TarefasTemplate { get; set; }
        public DbSet<TemplateModel> Templates{ get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ChecklistModel> checklists{ get; set; }
        public DbSet<NaoConformidadeModel> naoConformidades { get; set; }
        public DbSet<ItemCheckModel> itensCheckList{ get; set; }
        public DbSet<CheckListTemplateModel> checkListTemplates { get; set; }
        public DbSet<ItemChecklistTemplateModel> itemCheckListTemplates { get; set; }
        
    }
}
