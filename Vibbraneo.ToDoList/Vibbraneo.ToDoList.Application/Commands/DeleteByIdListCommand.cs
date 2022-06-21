using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibbraneo.ToDoList.Application.Interfaces;

namespace Vibbraneo.ToDoList.Application.Commands
{
    public class DeleteByIdListCommand : IRequest<ICommandResult>
    {
        public DeleteByIdListCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
