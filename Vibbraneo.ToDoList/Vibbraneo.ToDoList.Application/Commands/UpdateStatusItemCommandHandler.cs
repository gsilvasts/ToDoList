using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibbraneo.ToDoList.Application.Interfaces;
using Vibbraneo.ToDoList.Application.Utils;
using Vibbraneo.ToDoList.Domain.Interface.Repositories;

namespace Vibbraneo.ToDoList.Application.Commands
{
    public class UpdateStatusItemCommandHandler : BaseHandler, IRequestHandler<UpdateStatusItemCommand, ICommandResult>
    {
        private readonly IListRepository _listRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IUserRepository _userRepository;

        public UpdateStatusItemCommandHandler(IListRepository listRepository, IItemRepository itemRepository, IUserRepository userRepository)
        {
            _listRepository = listRepository;
            _itemRepository = itemRepository;
            _userRepository = userRepository;
        }

        public async Task<ICommandResult> Handle(UpdateStatusItemCommand request, CancellationToken cancellationToken)
        {            
            try
            {
                var entity = await _itemRepository.GetByIdAsync(request.Id);
                if (entity == null)
                    return NotFoundResult(request);

                var list = await _listRepository.GetByIdAsync(entity.ListId);

                if(list.UserId != request.UserId && entity.UserId != request.UserId)
                {
                    return ErrorResult("UUser without editing permission on the item.", entity);
                }

                entity.UpdateStatus(request.Status);

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
