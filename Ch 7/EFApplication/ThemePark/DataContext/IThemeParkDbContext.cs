using EFApplication.DataContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFApplication.DataContext;

public interface IThemeParkDbContext
{
    DbSet<Attraction> Attractions { get; set; }
    DbSet<Location> Locations { get; set; }
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    DatabaseFacade Database { get; }
}
