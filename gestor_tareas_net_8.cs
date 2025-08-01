using GestorTareas.Data;
using GestorTareas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddControllersWithViews();

// Configuración de la base de datos SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configuración de la aplicación
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// ApplicationDbContext.cs
namespace GestorTareas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Tarea> Tareas { get; set; }
    }
}




// Views/Tareas/Create.cshtml
@model GestorTareas.Models.Tarea

<h2>Crear Tarea</h2>
<form asp-action="Create" method="post">
    <div class="form-group">
        <label asp-for="Titulo"></label>
        <input asp-for="Titulo" class="form-control" />
    </div>
    <div class="form-group">
        <label asp-for="Descripcion"></label>
        <textarea asp-for="Descripcion" class="form-control"></textarea>
    </div>
    <div class="form-check">
        <input asp-for="Completada" class="form-check-input" />
        <label asp-for="Completada" class="form-check-label"></label>
    </div>
    <button type="submit" class="btn btn-primary mt-2">Guardar</button>
</form>
<a asp-action="Index" class="btn btn-secondary mt-2">Volver</a>
