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
using Vibbraneo.ToDoList.Domain.Interface.Services;

namespace Vibbraneo.ToDoList.Application.Commands.UserManager
{
    public class LoginCommandHandler : BaseHandler, IRequestHandler<LoginCommand, ICommandResult>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public LoginCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<ICommandResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputerSha256Hash(request.Password);

            var user = await _userRepository.GetByUserNameAndPassword(request.UserName, passwordHash);

            if (user == null)
                return ErrorResult("Invalid username or password.", request);

            var token = _authService.GenerateJwtToken(user);

            var userviewModel =new UserViewModel { Id = user.Id, Name = user.Name };

            var login = new LoginViewModel
            {
                Token = token,
                User = userviewModel
            };

            return SuccessResult(login);
        }
    }
}
