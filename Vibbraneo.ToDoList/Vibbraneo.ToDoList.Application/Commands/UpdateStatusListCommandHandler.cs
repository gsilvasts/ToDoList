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
    public class UpdateStatusListCommandHandler : BaseHandler, IRequestHandler<UpdateStatusListCommand, ICommandResult>
    {
        private readonly IListRepository _listRepository;        
        private readonly IUserRepository _userRepository;

        public UpdateStatusListCommandHandler(IListRepository listRepository, IUserRepository userRepository)
        {
            _listRepository = listRepository;
            _userRepository = userRepository;
        }

        public async Task<ICommandResult> Handle(UpdateStatusListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _listRepository.GetByIdAsync(request.Id);
                if (entity == null)
                    return NotFoundResult();

                if(entity.UserId != request.UserId)
                    return ErrorResult("User without editing permission on the item.", entity);

                entity.UpdateStatus(request.Status);

                await _listRepository.SaveChangeAsync();

                return SuccessResult(entity);
            }
            catch (Exception ex)
            {
                return ErrorResult(ex.Message);
            }
        }
    }
}
