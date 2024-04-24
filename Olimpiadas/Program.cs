using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Olimpiadas.Dominio.Repositorios;
using Olimpiadas.Infraestructura.Contextos;
using Olimpiadas.Infraestructura.Repositorios;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
var connectionString = configuration.GetSection("AppDb").Value;

SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
connectionStringBuilder.ConnectionString = connectionString;
connectionStringBuilder.ApplicationName = "AplicacionOlimpiadas";

builder.Services.AddDbContext<IContextoBase, Contexto>(opt =>
    opt.UseSqlServer(connectionStringBuilder.ToString())
);

builder.Services.AddTransient<IRepositorioGenerico, RepositorioGenerico>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();