using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibbraneo.ToDoList.Application.Interfaces;
using Vibbraneo.ToDoList.Application.Utils;
using Vibbraneo.ToDoList.Domain.Interface.Repositories;
using Vibbraneo.ToDoList.Domain.Interface.Services;

namespace Vibbraneo.ToDoList.Application.Commands.UserManager
{
    public class ChangePasswordCommandHandler : BaseHandler, IRequestHandler<ChangePasswordCommand, ICommandResult>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public ChangePasswordCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<ICommandResult> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var passwordHash = _authService.ComputerSha256Hash(request.Password);
                var user = await _userRepository.GetByUserNameAndPassword(request.UserName, passwordHash);

                if (user == null)
                    return ErrorResult("Invalid current password.", request);

                var newPasswordHash = _authService.ComputerSha256Hash(request.NewPassword);

                user.ChangePassword(newPasswordHash);

                await _userRepository.SaveChangeAsync();

                return SuccessResult(user);
                                
            }
            catch (Exception ex)
            {
                return ErrorResult(ex.Message);
            }
        }
    }
}
