using MediatR;
using Vibbraneo.ToDoList.Application.Interfaces;
using Vibbraneo.ToDoList.Domain.Dtos.InputModel;

namespace Vibbraneo.ToDoList.Application.Commands
{
    public class CreateListCommand : IRequest<ICommandResult>
    {
        public CreateListCommand(Guid userId, CreateListInputModel taskList)
        {
            UserId = userId;
            TaskList = taskList;
        }

        public Guid UserId { get; set; }
        public CreateListInputModel TaskList { get; set; }
    }
}
