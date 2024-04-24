using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Persistance;
public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"User ID=postgres;Password=mmad;Host=localhost;Port=5432;Database=ConsoleDb;Pooling=true;");
    }
}