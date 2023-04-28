using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkPatterns.SpecificationPattern;

public static class SpecificationBuilder<TEntity> where TEntity: class
{
    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, 
        ISpecification<TEntity> specification)
    {
        var query = inputQuery;
        
        if (specification == null)
        {
            return query;
        }

        if (specification.Filter != null)
        {
            query = query.Where(specification.Filter);
        }

        if (specification.Includes != null 
            && specification.Includes.Any())
        {
            foreach (var include in specification.Includes)
            {
                query = query.Include(include);
            }
        }

        if (specification.OrderBy != null)
        {
            query = query
                .OrderBy(specification.OrderBy);
        }
        else if (specification.OrderByDescending != null)
        {
            query = query
                .OrderByDescending(specification.OrderByDescending);
        }

        if (specification.GroupBy != null)
        {
            query = query
                .GroupBy(specification.GroupBy)
                .SelectMany(x => x);
        }

        return query;
    }
}
