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
    public async Task<string> WhatsMyIp() => await _mediator.Send(new GetIpAddressQuery(HttpContext.Connection.RemoteIpAddress));
}
