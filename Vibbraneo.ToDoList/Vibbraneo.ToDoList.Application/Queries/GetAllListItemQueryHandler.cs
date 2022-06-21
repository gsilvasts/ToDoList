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
    public class GetAllListItemQueryHandler : IRequestHandler<GetAllListItemQuery, IEnumerable<ListItemViewModel>>
    {
        private readonly IListRepository _listRepository;

        public GetAllListItemQueryHandler(IListRepository listRepository)
        {
            _listRepository = listRepository;
        }

        public async Task<IEnumerable<ListItemViewModel>> Handle(GetAllListItemQuery request, CancellationToken cancellationToken)
        {
            var viewModel = await _listRepository.GetAllListItemAsync(request.UserId);

            return viewModel;
        }
    }
}
