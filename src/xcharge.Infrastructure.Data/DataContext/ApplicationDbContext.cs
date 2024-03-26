using Microsoft.EntityFrameworkCore;
using xcharge.Domain.Entities;

namespace xcharge.Infrastructure.Data.DataContext;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    static ApplicationDbContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<Condominium> Condominium { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Unit> Unit { get; set; }
    public DbSet<Block> Block { get; set; }
}
