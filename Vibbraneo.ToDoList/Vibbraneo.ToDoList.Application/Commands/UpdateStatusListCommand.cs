using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibbraneo.ToDoList.Application.Interfaces;
using Vibbraneo.ToDoList.Domain.Enums;

namespace Vibbraneo.ToDoList.Application.Commands
{
    public class UpdateStatusListCommand : IRequest<ICommandResult>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public StatusEnums Status { get; set; }
    }
}
