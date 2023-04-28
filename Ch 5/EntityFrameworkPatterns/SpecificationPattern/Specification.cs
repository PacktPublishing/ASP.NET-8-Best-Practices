using System.Linq.Expressions;

namespace EntityFrameworkPatterns.SpecificationPattern;

/// <inheritdoc />
public class Specification<TEntity>: ISpecification<TEntity> where TEntity: class
{
    public Expression<Func<TEntity, bool>> Filter { get; }
    public Expression<Func<TEntity, object>> OrderBy { get; set; } = null!;
    public Expression<Func<TEntity, object>> OrderByDescending { get; set; } = null!;
    public Expression<Func<TEntity, object>> GroupBy { get; set; } = null!;
    public List<Expression<Func<TEntity, object>>> Includes { get; } = null!;

    public Specification(Expression<Func<TEntity, bool>> filter)
    {
        Filter = filter;
    }
}
