using EntityFrameworkPatterns.DataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkPatterns.DataContext;

public class ThemeParkDbContext: DbContext, IThemeParkDbContext
{
    public virtual DbSet<Attraction> Attractions { get; set; }
    public virtual DbSet<Location> Locations { get; set; }

    public ThemeParkDbContext(DbContextOptions<ThemeParkDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "ThemeParkRides");

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AttractionConfiguration());
        modelBuilder.ApplyConfiguration(new LocationConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}