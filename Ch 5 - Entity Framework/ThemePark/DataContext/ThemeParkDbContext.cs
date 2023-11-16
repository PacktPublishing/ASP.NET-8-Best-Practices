using EntityFrameworkThemePark.DataContext.Configuration;
using EntityFrameworkThemePark.DataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkThemePark.DataContext;

public class ThemeParkDbContext: DbContext, IThemeParkDbContext
{
    private readonly IConfiguration _configuration;

    public virtual DbSet<Attraction> Attractions { get; set; } = null!;
    public virtual DbSet<Location> Locations { get; set; } = null!;

    public ThemeParkDbContext(
        DbContextOptions<ThemeParkDbContext> options,
        IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connString = _configuration.GetConnectionString("DefaultConnection");
            if (!string.IsNullOrEmpty(connString))
            {
                optionsBuilder.UseSqlServer(connString)
                    .LogTo(Console.WriteLine, LogLevel.Information);
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AttractionConfiguration());
        modelBuilder.ApplyConfiguration(new LocationConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}