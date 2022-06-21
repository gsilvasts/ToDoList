using Vibbraneo.ToDoList.Domain.Dtos.ViewModel;
using Vibbraneo.ToDoList.Domain.Entities;

namespace Vibbraneo.ToDoList.Domain.Interface.Repositories
{
    public interface IItemRepository : IRepository<Item>
    {
        Task<IEnumerable<ItemViewModel>> GetAllItemByUserAsync(Guid userId);
        Task<IEnumerable<ItemViewModel>> GetByIdItemAsync(Guid Id);
    }
}
