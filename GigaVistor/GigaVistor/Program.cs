using GigaVistor.Data;
using GigaVistor.Models;
using GigaVistor.Services.SetorServices;
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
