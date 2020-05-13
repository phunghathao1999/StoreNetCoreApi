using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task<T> GetByAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task RemoveAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);
        Task RemoveRangeAsync(IEnumerable<T> entities);

        Task<int> CountAsync();
        Task<int> CountAsync(ISpecification<T> spec);
        Task<IEnumerable<T>> FindAsync(ISpecification<T> spec);
    }
}
