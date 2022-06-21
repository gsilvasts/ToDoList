using MediatR;
using Vibbraneo.ToDoList.Application.Interfaces;
using Vibbraneo.ToDoList.Domain.Dtos.InputModel;

namespace Vibbraneo.ToDoList.Application.Commands
{
    public class UpdateListCommand : IRequest<ICommandResult>
    {
        public UpdateListCommand(Guid userId, UpdateListInputModel taskList)
        {
            UserId = userId;
            TaskList = taskList;
        }

        public Guid UserId { get; set; }
        public UpdateListInputModel TaskList { get; set; }
    }
}
