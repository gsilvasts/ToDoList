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
    public class GetListByIdQuery : IRequest<ICommandResult>
    {
        public GetListByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
