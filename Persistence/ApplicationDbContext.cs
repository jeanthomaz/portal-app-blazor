using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Token> Tokens { get; set; }
    
    public ApplicationDbContext()
    {
    }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(GetConnectionString());

    private string? _connectionString;
    private string GetConnectionString()
    {
        if (_connectionString == null)
        {
#if DEBUG
            _connectionString = "Host=localhost;Port=5432;Database=projeto_integrador;Username=postgres;Password=pass123";
            return _connectionString;
#endif
            var rdsConfig = new RdsConfig();
            _connectionString = rdsConfig.GetConnectionString().Result;
        }

        return _connectionString;
    }
}