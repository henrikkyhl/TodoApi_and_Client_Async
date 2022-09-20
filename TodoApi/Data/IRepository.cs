using System.Collections.Generic;

namespace TodoApi.Data
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(long id);
        Task AddAsync(T entity);
        Task EditAsync(T entity);
        Task RemoveAsync(long id);
    }
}
