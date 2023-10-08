using Core.Entities;
using Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<Presentation> Presentations { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }

    public ApplicationDbContext()
    {
    }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={GetDatabasePath()};");

    private string GetDatabasePath()
        => Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())!.FullName, "Persistence/mydb.db");
}