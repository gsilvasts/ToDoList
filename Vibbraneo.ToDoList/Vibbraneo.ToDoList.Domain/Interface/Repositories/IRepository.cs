using System.Linq.Expressions;
using Vibbraneo.ToDoList.Domain.Entities;

namespace Vibbraneo.ToDoList.Domain.Interface.Repositories
{
    public interface IRepository<T> : IDisposable where T : BaseEntity
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteByIdAsync(Guid id);
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task SaveChangeAsync();
        Task<IEnumerable<T>> FindByQueryAsync(Expression<Func<T, bool>> predicate);
    }
}
