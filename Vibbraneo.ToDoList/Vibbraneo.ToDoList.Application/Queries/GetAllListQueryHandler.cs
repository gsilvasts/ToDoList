using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibbraneo.ToDoList.Domain.Dtos.ViewModel;
using Vibbraneo.ToDoList.Domain.Interface.Repositories;

namespace Vibbraneo.ToDoList.Application.Queries
{
    public class GetAllListQueryHandler : IRequestHandler<GetAllListQuery, IEnumerable<ListViewModel>>
    {
        private readonly IListRepository _listRepository;

        public GetAllListQueryHandler(IListRepository listRepository)
        {
            _listRepository = listRepository;
        }

        public async Task<IEnumerable<ListViewModel>> Handle(GetAllListQuery request, CancellationToken cancellationToken)
        {
            var viewModel = await _listRepository.GetAllListByUserAsync(request.UserId);

            return viewModel;
                       
        }
    }
}
