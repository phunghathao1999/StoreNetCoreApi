using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Infrastructure.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }
        protected DbContext Context => _context;
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            await Task.Run(() => _context.Set<T>().Remove(entity));
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            await Task.Run(() => _context.Set<T>().RemoveRange(entities));
        }
    }
}
