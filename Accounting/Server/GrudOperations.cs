using Accounting.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Server
{
    public class GrudOperations<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext Context;
        public GrudOperations(ApplicationDbContext context)
        {
            this.Context = context;
        }
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await Context.Set<TEntity>().AsNoTracking().ToListAsync();
        public virtual async Task<TEntity> UpdateOrAddAsync(TEntity entity)
        {
            if (entity.Id == 0)
                await Context.AddAsync<TEntity>(entity);
            else
                Context.Update<TEntity>(entity);

            await Context.SaveChangesAsync();
            return entity;
        }
        public virtual async Task<IEnumerable<TEntity>> UpdateOrAddRangeAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                if (entity.Id == 0)
                    await Context.AddAsync<TEntity>(entity);
                else
                    Context.Update<TEntity>(entity);

            await Context.SaveChangesAsync();
            return entities;
        }
        public virtual async Task RemoveAsync(TEntity item)
        {
            Context.Set<TEntity>().Remove(item);
            await Context.SaveChangesAsync();
        }
        public virtual async Task RemoveRangeAsunc(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
            await Context.SaveChangesAsync();
        }
    }
}