using DevExpress.Xpo;
using System;

namespace Accounting.Server
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> UpdateOrAddAsync(T entity);
        Task<IEnumerable<T>> UpdateOrAddRangeAsync(IEnumerable<T> entities);
        Task RemoveAsync(T item);
        Task RemoveRangeAsunc(IEnumerable<T> entities);
    }

}