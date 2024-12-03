using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockPilot.Api.Application.AppSite.commands;
using StockPilot.Api.Application.AppSite.Queries;

namespace StockPilot.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SiteController: ControllerBase
    {
        private readonly IMediator _mediator;

        public SiteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> create([FromBody] CreateSiteCommand command)
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
            var result = await _mediator.Send(new GetAllSitesQuery());
            return Ok(result); 
        }
        [HttpGet("societe/{societeId}")]
        public async Task<IActionResult> GetBysocieteId(int societeId) 
        {
            var result = await _mediator.Send(new GetSitesBySocieteIdQuery (societeId));
            return Ok(result);
        }
    }
}
