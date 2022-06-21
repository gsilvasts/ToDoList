using MediatR;
using Vibbraneo.ToDoList.Application.Interfaces;
using Vibbraneo.ToDoList.Application.Utils;
using Vibbraneo.ToDoList.Domain.Interface.Repositories;

namespace Vibbraneo.ToDoList.Application.Commands
{
    public class UpdateListCommandHandler : BaseHandler, IRequestHandler<UpdateListCommand, ICommandResult>
    {
        private readonly IListRepository _listRepository;

        public UpdateListCommandHandler(IListRepository listRepository)
        {
            _listRepository = listRepository;
        }

        public async Task<ICommandResult> Handle(UpdateListCommand request, CancellationToken cancellationToken)
        {
            var inputModel = request.TaskList;
            try
            {
                var entity = await _listRepository.GetByIdAsync(inputModel.Id);

                if (entity == null)
                    return NotFoundResult(inputModel);

                entity.Update(inputModel.Title, inputModel.Description, inputModel.Status);

                await _listRepository.SaveChangeAsync();

                return SuccessResult(entity);
                
            }
            catch (Exception ex)
            {
                return ErrorResult(ex.Message);
            }
        }
    }
}
