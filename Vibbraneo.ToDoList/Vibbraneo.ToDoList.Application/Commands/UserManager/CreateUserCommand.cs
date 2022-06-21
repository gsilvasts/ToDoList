using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibbraneo.ToDoList.Application.Interfaces;

namespace Vibbraneo.ToDoList.Application.Commands.UserManager
{
    public class CreateUserCommand : IRequest<ICommandResult>
    {
        public CreateUserCommand(string name, string email, string userName, string password)
        {
            Name = name;
            Email = email;
            UserName = userName;
            Password = password;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
