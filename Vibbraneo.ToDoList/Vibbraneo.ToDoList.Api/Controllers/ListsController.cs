using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vibbraneo.ToDoList.Application.Commands;
using Vibbraneo.ToDoList.Application.Queries;

namespace Vibbraneo.ToDoList.Api.Controllers
{    
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/lists")]
    [Authorize]
    public class ListsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ListsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get a list through your ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetListByIdQuery(id);
            var result = await _mediator.Send(query);

            if (!result.Success())
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Create a new list.
        /// </summary>
        /// <remarks>
        /// <h1>Status</h1>
        /// <p>1=ToDo; 2 Done</p>
        /// </remarks>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateListCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success())
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Deletes a list by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteByIdListCommand(id);

            var result = await _mediator.Send(command);

            if (!result.Success())
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Get items from a list.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/items")]
        public async Task<IActionResult> GetItemsById(Guid id)
        {
            var query = new GetAllItemQuery(id);

            var result = await _mediator.Send(query);

            if (!result.Success())
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Create items from a list.
        /// </summary>
        /// <remarks>
        /// <h1>Status</h1>
        /// <p>1=ToDo; 2 Done</p>
        /// </remarks>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("{id}/items")]
        public async Task<IActionResult> Post([FromBody] CreateItemCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success())
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Update an item.
        /// </summary>
        /// <param name="command"></param>
        /// <remarks>
        /// <h1>Status</h1>
        /// <p>1=ToDo; 2 Done</p>
        /// </remarks>
        /// <returns></returns>
        [HttpPut("{id}/items/{itemId}")]
        public async Task<IActionResult> Put([FromBody] UpdateItemCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success())
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Deletes an item by an ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [HttpDelete("{id}/items/{itemId}")]        
        public async Task<IActionResult> DeleteItemById(Guid id, Guid itemId)
        {
            var command = new DeleteByIdItemCommand(id, itemId);

            var result = await _mediator.Send(command);

            if (!result.Success())
                return BadRequest(result);

            return Ok(result);
        }
    }
}
