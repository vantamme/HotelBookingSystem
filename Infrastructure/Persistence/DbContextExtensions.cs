using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence;

public static class Extensions
{
    public static IQueryable<T> FindAll<T>(this DbSet<T> dbSet, bool trackChanges) where T : class =>
        !trackChanges ? dbSet.AsNoTracking() : dbSet;

    public static IQueryable<T> FindByCondition<T>(this DbSet<T> dbSet, Expression<Func<T, bool>> expression, bool trackChanges) where T : class =>
            !trackChanges ? dbSet.Where(expression).AsNoTracking() : dbSet.Where(expression);
}
