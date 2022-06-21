using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibbraneo.ToDoList.Application.Interfaces;
using Vibbraneo.ToDoList.Domain.Dtos.ViewModel;

namespace Vibbraneo.ToDoList.Application.Queries
{
    public class GetAllItemQuery : IRequest<ICommandResult>
    {
        public GetAllItemQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
