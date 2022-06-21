using Microsoft.EntityFrameworkCore;
using Vibbraneo.ToDoList.Domain.Dtos.ViewModel;
using Vibbraneo.ToDoList.Domain.Entities;
using Vibbraneo.ToDoList.Domain.Interface.Repositories;

namespace Vibbraneo.ToDoList.Infraestrutura.Persistence.Repositories
{
    public class ListRepository : Repository<TaskList>, IListRepository
    {
        public ListRepository(ToDoListContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ListViewModel>> GetAllListByUserAsync(Guid userId)
        {
            var viewModel = _dbSet.Where(x => x.UserId == userId)
                .Select(x => new ListViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    CreateAt = x.CreateAt,
                    UpdateAt = x.UpdateAt.Value,
                    Title = x.Title,
                    Status = x.Status
                });

            return viewModel;
        }

        public async Task<IEnumerable<ListItemViewModel>> GetAllListItemAsync(Guid userId)
        {
            var viewModel = _dbSet
                .Include(x => x.User)
                .Include(x => x.Items)
                .ThenInclude(x => x.Items)
                .Where(x => x.UserId == userId)
                .Select(x => new ListItemViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    CreateAt = x.CreateAt,
                    UpdateAt = x.UpdateAt.Value,
                    Title = x.Title,
                    Status = x.Status,       
                    UserId = x.User.Id,
                    Name = x.User.Name,
                    Items = x.Items.Select(x => new ItemViewModel { Id = x.Id, CreateAt = x.CreateAt, Title = x.Title, Description = x.Description, Status = x.Status, UpdateAt = x.UpdateAt.Value }).ToList(),
                });

            return viewModel;
        }

        public async Task<ListViewModel> GetByIdListAsync(Guid id)
        {
            var viewModel = _dbSet
                .Where(x => x.Id == id)
                .Select(x => new ListViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    CreateAt = x.CreateAt,
                    UpdateAt = x.UpdateAt,
                    Title = x.Title,
                    Status = x.Status
                }).FirstOrDefaultAsync();

            return await viewModel;

        }
    }
}
