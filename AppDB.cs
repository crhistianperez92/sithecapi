using Microsoft.EntityFrameworkCore;
using sithecapi.models;
namespace sithecapi;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<HumanoModel> Humanos { get; set; }

    // Otros DbSet y configuraciones según tus necesidades
}