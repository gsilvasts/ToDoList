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
    public class DeleteByIdItemCommandHandler : BaseHandler, IRequestHandler<DeleteByIdItemCommand, ICommandResult>
    {
        private readonly IItemRepository _itemRepository;

        public DeleteByIdItemCommandHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<ICommandResult> Handle(DeleteByIdItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _itemRepository.DeleteByIdAsync(request.ItemId);
                if (!result)
                    return ErrorResult("No Object found with the given Id.", request.ItemId);

                return SuccessResult();
            }
            catch (Exception ex)
            {
                return ErrorResult(ex.Message);
            }
        }
    }
}
