using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibbraneo.ToDoList.Application.Interfaces;

namespace Vibbraneo.ToDoList.Application.Commands
{
    public class DeleteByIdItemCommand : IRequest<ICommandResult>
    {
        public DeleteByIdItemCommand(Guid id, Guid itemId)
        {
            Id = id;
            ItemId = itemId;
        }

        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
    }
}
