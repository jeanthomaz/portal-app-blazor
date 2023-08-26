using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ApplicationDbContext  : DbContext
{
    public DbSet<Presentation> Presentations { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }

    public ApplicationDbContext()
    {
    }
    
    public ApplicationDbContext (DbContextOptions<ApplicationDbContext > options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=mydb.db;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Presentation>().HasKey(p => p.Id);
        modelBuilder.Entity<Presentation>().ToTable("Presentation");
        
        modelBuilder.Entity<Student>().HasKey(p => p.Id);
        modelBuilder.Entity<Student>().ToTable("Student");
        
        modelBuilder.Entity<Group>().HasKey(p => p.Id);
        modelBuilder.Entity<Group>().ToTable("Group");
    }
}