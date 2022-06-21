using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibbraneo.ToDoList.Application.Interfaces;

namespace Vibbraneo.ToDoList.Application.Commands.UserManager
{
    public class UpdateUserCommand : IRequest<ICommandResult>
    {
        public UpdateUserCommand(Guid id, string name, string userName, string email)
        {
            Id = id;
            Name = name;
            UserName = userName;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }        
    }
}
