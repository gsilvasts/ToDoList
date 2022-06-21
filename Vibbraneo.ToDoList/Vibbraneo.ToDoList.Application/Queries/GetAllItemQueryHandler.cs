using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibbraneo.ToDoList.Application.Interfaces;
using Vibbraneo.ToDoList.Application.Utils;
using Vibbraneo.ToDoList.Domain.Dtos.ViewModel;
using Vibbraneo.ToDoList.Domain.Interface.Repositories;

namespace Vibbraneo.ToDoList.Application.Queries
{
    public class GetAllItemQueryHandler : BaseHandler, IRequestHandler<GetAllItemQuery, ICommandResult>
    {
        private readonly IItemRepository _itemRepository;

        public GetAllItemQueryHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<ICommandResult> Handle(GetAllItemQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var viewModel = await _itemRepository.GetByIdItemAsync(request.Id);
                if (viewModel == null)
                    return ErrorResult("No Object found with the given Id.", request.Id);

                return SuccessResult(viewModel);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
