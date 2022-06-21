using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibbraneo.ToDoList.Application.Interfaces;
using Vibbraneo.ToDoList.Application.Utils;
using Vibbraneo.ToDoList.Domain.Entities;
using Vibbraneo.ToDoList.Domain.Interface.Repositories;
using Vibbraneo.ToDoList.Domain.Interface.Services;

namespace Vibbraneo.ToDoList.Application.Commands.UserManager
{
    public class CreateUserCommandHandler : BaseHandler, IRequestHandler<CreateUserCommand, ICommandResult>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<ICommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputerSha256Hash(request.Password);
            
            try
            {
                var user = new User(request.Name, request.Email, request.UserName, passwordHash);

                var result = await _userRepository.CreateAsync(user);

                if(result==null)
                    return ErrorResult("Unable to create user.", user);

                return SuccessResult(result);

            }
            catch (Exception ex)
            {
                return ErrorResult(ex.Message);
            }
        }
    }
}
