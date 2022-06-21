using Vibbraneo.ToDoList.Domain.Dtos.ViewModel;
using Vibbraneo.ToDoList.Domain.Entities;

namespace Vibbraneo.ToDoList.Domain.Interface.Repositories
{
    public interface IListRepository : IRepository<TaskList>
    {
        Task<IEnumerable<ListViewModel>> GetAllListByUserAsync(Guid userId);
        Task<IEnumerable<ListItemViewModel>> GetAllListItemAsync(Guid userId);
        Task<ListViewModel> GetByIdListAsync(Guid id);
    }
}
