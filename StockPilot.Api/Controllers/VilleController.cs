using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockPilot.Api.Application.AppVille.Queries;

namespace StockPilot.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class VilleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VilleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllVillesQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById (int id)
        {
            var result = await _mediator.Send(new GetVilleByIdQuery(id));
            return Ok(result);
        }
    }
}
