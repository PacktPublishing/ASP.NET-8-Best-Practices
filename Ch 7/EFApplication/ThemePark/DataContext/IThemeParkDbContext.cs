using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ThemePark.DataContext.Models;

namespace ThemePark.DataContext;

public interface IThemeParkDbContext
{
    DbSet<Attraction> Attractions { get; set; }
    DbSet<Location> Locations { get; set; }
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    DatabaseFacade Database { get; }
    
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}
