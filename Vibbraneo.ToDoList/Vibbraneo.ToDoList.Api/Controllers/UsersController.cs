using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vibbraneo.ToDoList.Application.Commands.UserManager;
using Vibbraneo.ToDoList.Application.Queries;

namespace Vibbraneo.ToDoList.Api.Controllers
{    
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/users")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get the user's data through the ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]        
        public async Task<IActionResult> Get(Guid id)
        {
            
            var query = new GetUserByIdQuery(id);
            var result = await _mediator.Send(query);

            if (!result.Success())
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Create a new user with username and password.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success())
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Create a new user with username and password.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success())
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Change Password.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}/change-password")]
        public async Task<IActionResult> Put([FromBody] ChangePasswordCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success())
                return BadRequest(result);

            return Ok(result);
        }
    }
}
