using Microsoft.EntityFrameworkCore;
using Vibbraneo.ToDoList.Domain.Entities;
using Vibbraneo.ToDoList.Domain.Interface.Repositories;

namespace Vibbraneo.ToDoList.Infraestrutura.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ToDoListContext context) : base(context)
        {
        }

        public async Task<User> GetByUserNameAndPassword(string userName, string passwordHash)
        {
            return await _dbSet
                .SingleOrDefaultAsync(x=>x.UserName.Trim().ToUpper().Equals(userName.Trim().ToUpper()) && x.Password.Equals(passwordHash));
        }
    }
}
