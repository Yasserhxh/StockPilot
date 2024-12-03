using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockPilot.Api.Application.AppClient.Command;

namespace StockPilot.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ChangePasswordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChangePasswordController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            // Call the command handler
            var response = await _mediator.Send(command);

            if (response.Success)
            {
                return Ok(response) ; // Success
            }

            return BadRequest(response); // Failure
        }
    }
}
