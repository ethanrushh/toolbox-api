using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToolKitAPI.Core.Commands.Notes;
using ToolKitAPI.Data.DTOs.Notes;

namespace ToolKitAPI.Controllers;

[Microsoft.AspNetCore.Components.Route("/api/notes")]
[ApiController]
public class NotesController : ControllerBase
{
    private readonly IMediator _mediator;

    public NotesController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost("create")]
    public async Task<NoteReadDto> CreateNote([FromQuery] CreateNoteCommand command) => await _mediator.Send(command);
}
