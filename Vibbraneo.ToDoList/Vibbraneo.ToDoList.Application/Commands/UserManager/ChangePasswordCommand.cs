using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibbraneo.ToDoList.Application.Interfaces;

namespace Vibbraneo.ToDoList.Application.Commands.UserManager
{
    public class ChangePasswordCommand : IRequest<ICommandResult>
    {
        public ChangePasswordCommand(string userName, string password, string newPassword)
        {
            UserName = userName;
            Password = password;
            NewPassword = newPassword;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}
