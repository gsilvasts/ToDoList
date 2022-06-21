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
    public class GetListByIdQueryHandler : BaseHandler, IRequestHandler<GetListByIdQuery, ICommandResult>
    {
        private readonly IListRepository _listRepository;

        public GetListByIdQueryHandler(IListRepository listRepository)
        {
            _listRepository = listRepository;
        }

        public async Task<ICommandResult> Handle(GetListByIdQuery request, CancellationToken cancellationToken)
        {
            var viewModel = await _listRepository.GetByIdListAsync(request.Id);

            if (viewModel == null)
                return ErrorResult("No Object found with the given Id.", request.Id);

            return SuccessResult(viewModel);            
        }
    }
}
