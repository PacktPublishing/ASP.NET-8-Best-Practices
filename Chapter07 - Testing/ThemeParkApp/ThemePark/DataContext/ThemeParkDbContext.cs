using Microsoft.EntityFrameworkCore;
using ThemePark.DataContext.Configuration;
using ThemePark.DataContext.Models;

namespace ThemePark.DataContext;

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
                optionsBuilder.UseSqlServer(connString);
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