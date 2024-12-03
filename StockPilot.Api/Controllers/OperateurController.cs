using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockPilot.Api.Application.AppOperateur.Commands;
using StockPilot.Api.Application.AppOperateur.Queries;

namespace StockPilot.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OperateurController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OperateurController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateOperateurCommand command)
        {
            var response = await _mediator.Send(command);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllOperateursQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        { 
            var result = await _mediator.Send(new GetOperateurByIdQuery(id));
            return Ok(result);
        }
    }
}
