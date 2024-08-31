using FavortieList.WebAPI.Context;
using Microsoft.EntityFrameworkCore;

namespace FavoriteList.WebAPI.Repositories;

public abstract class Repository<T>(ApplicationDbContext context) where T : class
{
    public async Task<List<T>> GetAllAsnyc(CancellationToken cancellationToken = default)
    {
        List<T> list = await context.Set<T>().ToListAsync(cancellationToken);
        return list;
    }

    public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await context.Set<T>().AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        context.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Set<T>().FindAsync(id, cancellationToken);
    }

    public async Task DeleteByIdAsync(T entity, CancellationToken cancellationToken = default)
    {
        context.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
    }
}