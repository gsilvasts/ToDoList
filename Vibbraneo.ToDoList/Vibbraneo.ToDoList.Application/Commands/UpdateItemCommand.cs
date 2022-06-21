using MediatR;
using Vibbraneo.ToDoList.Application.Interfaces;
using Vibbraneo.ToDoList.Domain.Dtos.InputModel;

namespace Vibbraneo.ToDoList.Application.Commands
{
    public class UpdateItemCommand : IRequest<ICommandResult>
    {
        public UpdateItemCommand(Guid userId, UpdateItemInputModel item)
        {
            UserId = userId;
            Item = item;
        }

        public Guid UserId { get; set; }
        public UpdateItemInputModel Item { get; set; }
    }
}
