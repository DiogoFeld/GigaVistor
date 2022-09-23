using GigaVistor.Data;
using GigaVistor.Models;
using GigaVistor.Services.AgendamentoServices;
using GigaVistor.Services.AuditoriaServices;
using GigaVistor.Services.LoginService;
using GigaVistor.Services.ProjetoServices;
using GigaVistor.Services.SetorServices;
using GigaVistor.Services.TarefaServices;
using GigaVistor.Services.TarefaTemplateServices;
using GigaVistor.Services.TemplateServices;
using GigaVistor.Services.UsuarioServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GigaVistorContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EFConnection"));

});

builder.Services.AddScoped<ISetorService, SetorService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IProjetoService, ProjetoService>();
builder.Services.AddScoped<IAuditoriaService, AuditoriaService>();
builder.Services.AddScoped<ITarefaService, TarefaService>();
builder.Services.AddScoped<IAgendamentoService, AgendamentoService>();
builder.Services.AddScoped<ITarefaTemplateService, TarefaTemplateService>();
builder.Services.AddScoped<ITemplateService, TemplateService>();
builder.Services.AddScoped<ILoginService, LoginService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
//pattern: "{controller=Home}/{action=Index}/{id?}");
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
