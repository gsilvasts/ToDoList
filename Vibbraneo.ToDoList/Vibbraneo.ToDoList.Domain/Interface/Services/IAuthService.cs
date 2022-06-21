using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibbraneo.ToDoList.Domain.Entities;

namespace Vibbraneo.ToDoList.Domain.Interface.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user);
        string ComputerSha256Hash(string password);
    }
}
