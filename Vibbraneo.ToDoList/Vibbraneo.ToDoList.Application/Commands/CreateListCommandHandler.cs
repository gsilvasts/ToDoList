using MediatR;
using Vibbraneo.ToDoList.Application.Interfaces;
using Vibbraneo.ToDoList.Application.Utils;
using Vibbraneo.ToDoList.Domain.Entities;
using Vibbraneo.ToDoList.Domain.Interface.Repositories;

namespace Vibbraneo.ToDoList.Application.Commands
{
    public class CreateListCommandHandler : BaseHandler, IRequestHandler<CreateListCommand, ICommandResult>
    {
        private readonly IListRepository _listRepository;

        public CreateListCommandHandler(IListRepository listRepository)
        {
            _listRepository = listRepository;
        }

        public async Task<ICommandResult> Handle(CreateListCommand request, CancellationToken cancellationToken)
        {
            var inputModel = request.TaskList;
            try
            {
                var entity = new TaskList(request.UserId, inputModel.Title, inputModel.Description, inputModel.Status);

                var result = await _listRepository.CreateAsync(entity);

                if(result == null)
                {
                    return ErrorResult(entity);
                }

                return SuccessResult(result);

            }
            catch (Exception ex)
            {
                return ErrorResult(ex.Message);
            }
        }
    }
}
