using MediatR;
using Vibbraneo.ToDoList.Application.Interfaces;
using Vibbraneo.ToDoList.Domain.Dtos.InputModel;

namespace Vibbraneo.ToDoList.Application.Commands
{
    public class CreateItemCommand : IRequest<ICommandResult>
    {
        public CreateItemCommand(Guid userId, CreateItemInputModel item)
        {
            UserId = userId;
            Item = item;
        }

        public Guid UserId { get; set; }
        public CreateItemInputModel Item { get; set; }
    }
}
