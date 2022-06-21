using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibbraneo.ToDoList.Application.Interfaces;
using Vibbraneo.ToDoList.Application.Utils;
using Vibbraneo.ToDoList.Domain.Interface.Repositories;

namespace Vibbraneo.ToDoList.Application.Commands.UserManager
{
    public class UpdateUserCommandHandler : BaseHandler, IRequestHandler<UpdateUserCommand, ICommandResult>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ICommandResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _userRepository.GetByIdAsync(request.Id);

                if (entity == null)
                    return NotFoundResult();

                entity.Update(request.Name, request.Email, request.UserName);

                await _userRepository.SaveChangeAsync();

                return SuccessResult(entity);
            }
            catch (Exception ex)
            {
                return ErrorResult(ex.Message);
            }
        }
    }
}
