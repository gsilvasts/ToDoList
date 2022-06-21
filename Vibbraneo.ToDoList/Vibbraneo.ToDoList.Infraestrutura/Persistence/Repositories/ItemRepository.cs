using Microsoft.EntityFrameworkCore;
using Vibbraneo.ToDoList.Domain.Dtos.ViewModel;
using Vibbraneo.ToDoList.Domain.Entities;
using Vibbraneo.ToDoList.Domain.Interface.Repositories;

namespace Vibbraneo.ToDoList.Infraestrutura.Persistence.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(ToDoListContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ItemViewModel>> GetAllItemByUserAsync(Guid userId)
        {
            var viewModel = _dbSet
                .Include(x => x.Items)
                .Where(x => x.UserId == userId)
                .Select(x => new ItemViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    CreateAt = x.CreateAt,
                    SubItems = x.Items.Select(x=> new ItemViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Description = x.Description,
                        CreateAt = x.CreateAt,
                        UpdateAt = x.UpdateAt,
                        Status = x.Status
                    }).ToList(),
                    UpdateAt = x.UpdateAt,                    
                    Status = x.Status
                });

            return viewModel;
        }

        public async Task<IEnumerable<ItemViewModel>> GetByIdItemAsync(Guid Id)
        {
            var viewModel = _dbSet
                .Include(x => x.Items)
                .Where(x => x.ListId == Id)
                .Select(x => new ItemViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    CreateAt = x.CreateAt,
                    SubItems = x.Items == null? null: x.Items.Select(x => new ItemViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Description = x.Description,
                        CreateAt = x.CreateAt,
                        UpdateAt = x.UpdateAt,
                        Status = x.Status
                    }).ToList(),
                    UpdateAt = x.UpdateAt,
                    Status = x.Status
                });

            return viewModel;
        }
    }
}
