using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToolKitAPI.Core.Queries;

namespace ToolKitAPI.Controllers;

[Route("/api")]
[ApiController]
public class MainController : ControllerBase
{
    private readonly IMediator _mediator;

    public MainController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    
    [HttpGet("whats-my-ip")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [EndpointDescription("Returns the IPV4 address of an inbound request")]
    public async Task<IActionResult> WhatsMyIp()
    {
        return BadRequest("Proving that tests work");
        //return await _mediator.Send(new GetIpAddressQuery(HttpContext.Connection.RemoteIpAddress));
    }
}
