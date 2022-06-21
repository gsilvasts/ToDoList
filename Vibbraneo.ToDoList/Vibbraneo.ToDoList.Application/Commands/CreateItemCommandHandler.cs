using MediatR;
using Vibbraneo.ToDoList.Application.Interfaces;
using Vibbraneo.ToDoList.Application.Utils;
using Vibbraneo.ToDoList.Domain.Entities;
using Vibbraneo.ToDoList.Domain.Interface.Repositories;

namespace Vibbraneo.ToDoList.Application.Commands
{
    public class CreateItemCommandHandler : BaseHandler, IRequestHandler<CreateItemCommand, ICommandResult>
    {
        private readonly IListRepository _listRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IUserRepository _userRepository;

        public CreateItemCommandHandler(IListRepository listRepository, IItemRepository itemRepository, IUserRepository userRepository)
        {
            _listRepository = listRepository;
            _itemRepository = itemRepository;
            _userRepository = userRepository;
        }

        public async Task<ICommandResult> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var inputModel = request.Item;
            try
            {
                var list = await _listRepository.GetByIdAsync(inputModel.ListId);
                if (list == null)
                    return ErrorResult("List not found!", inputModel.ListId);

                if(list.UserId != inputModel.UserId)
                    return ErrorResult("Only the list owner can enter items.", null);

                var entity = new Item(list.Id, inputModel.ItemId, inputModel.UserId, inputModel.Title, inputModel.Description, inputModel.Status);

                var result = await _itemRepository.CreateAsync(entity);

                return SuccessResult(result);
            }
            catch (Exception ex)
            {
                return ErrorResult(ex.Message);
            }
        }
    }
}
