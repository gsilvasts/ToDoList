using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vibbraneo.ToDoList.Application.Commands.UserManager;

namespace Vibbraneo.ToDoList.Api.Controllers
{    
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/authenticate")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Perform user authentication
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success())
                return BadRequest(result);

            return Ok(result);
        }
    }
}
