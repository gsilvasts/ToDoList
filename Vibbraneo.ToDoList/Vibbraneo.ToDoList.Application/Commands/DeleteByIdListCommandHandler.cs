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
    public class DeleteByIdListCommandHandler : BaseHandler, IRequestHandler<DeleteByIdListCommand, ICommandResult>
    {
        private readonly IListRepository _listRepository;

        public DeleteByIdListCommandHandler(IListRepository listRepository)
        {
            _listRepository = listRepository;
        }

        public async Task<ICommandResult> Handle(DeleteByIdListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _listRepository.DeleteByIdAsync(request.Id);
                if (!result)
                    return ErrorResult("No Object found with the given Id.", request.Id);

                return SuccessResult();
            }
            catch (Exception ex)
            {
                return ErrorResult(ex.Message);
            }
        }
    }
}
