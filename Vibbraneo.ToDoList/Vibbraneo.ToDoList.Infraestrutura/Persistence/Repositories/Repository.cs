using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Vibbraneo.ToDoList.Domain.Entities;
using Vibbraneo.ToDoList.Domain.Interface.Repositories;

namespace Vibbraneo.ToDoList.Infraestrutura.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ToDoListContext _context;
        protected readonly DbSet<T> _dbSet;

        private bool disposed;

        public Repository(ToDoListContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }

        public async Task<T> CreateAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var result = await _dbSet.SingleOrDefaultAsync(p => p.Id == id);

            if (result == null)
                return false;

            _dbSet.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> FindByQueryAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await _dbSet.Where(predicate).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var result = await _dbSet.SingleOrDefaultAsync(p => p.Id == id);

            return result;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }

        public async void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
