using Vibbraneo.ToDoList.Domain.Entities;

namespace Vibbraneo.ToDoList.Domain.Interface.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUserNameAndPassword(string userName, string passwordHash);
    }
}
