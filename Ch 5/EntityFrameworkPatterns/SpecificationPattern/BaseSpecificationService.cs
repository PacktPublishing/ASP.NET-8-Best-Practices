using EntityFrameworkPatterns.DataContext;

namespace EntityFrameworkPatterns.SpecificationPattern;

public abstract class BaseSpecificationService<TEntity> where TEntity : class
{
    private readonly IThemeParkDbContext _context;

    protected BaseSpecificationService(IThemeParkDbContext context)
    {
        _context = context;
    }

    protected ISpecification<TEntity> Specification { get; set; } = null!;

    public IQueryable<TEntity> GetQuery()
    {
        return SpecificationBuilder<TEntity>
            .GetQuery(_context.Set<TEntity>().AsQueryable(), Specification);
    }
}
