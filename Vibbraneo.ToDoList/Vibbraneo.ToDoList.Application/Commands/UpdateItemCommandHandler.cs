using MediatR;
using Vibbraneo.ToDoList.Application.Interfaces;
using Vibbraneo.ToDoList.Application.Utils;
using Vibbraneo.ToDoList.Domain.Interface.Repositories;

namespace Vibbraneo.ToDoList.Application.Commands
{
    public class UpdateItemCommandHandler : BaseHandler, IRequestHandler<UpdateItemCommand, ICommandResult>
    {
        private readonly IListRepository _listRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IUserRepository _userRepository;

        public UpdateItemCommandHandler(IListRepository listRepository, IItemRepository itemRepository, IUserRepository userRepository)
        {
            _listRepository = listRepository;
            _itemRepository = itemRepository;
            _userRepository = userRepository;
        }

        public async Task<ICommandResult> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var inputModel = request.Item;

            try
            {
                var entity = await _itemRepository.GetByIdAsync(inputModel.Id);

                if (entity == null)
                    return NotFoundResult(inputModel);

                var list = await _listRepository.GetByIdAsync(entity.ListId);

                if (list.UserId != request.UserId || entity.UserId != request.UserId)
                    return ErrorResult("User without editing permission on the item.");

                entity.Update(inputModel.UserId, inputModel.Title, inputModel.Description, inputModel.Status);

                await _itemRepository.SaveChangeAsync();

                return SuccessResult(entity);
            }
            catch (Exception ex)
            {
                return ErrorResult(ex.Message);
            }
        }
    }
}
