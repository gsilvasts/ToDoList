using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibbraneo.ToDoList.Domain.Dtos.ViewModel;

namespace Vibbraneo.ToDoList.Application.Queries
{
    public class GetAllListItemQuery : IRequest<IEnumerable<ListItemViewModel>>
    {
        public GetAllListItemQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }
    }
}
