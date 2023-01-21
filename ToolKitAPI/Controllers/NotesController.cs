using Hellang.Middleware.ProblemDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToolKitAPI.Core.Commands.Notes;
using ToolKitAPI.Core.Exceptions;
using ToolKitAPI.Core.Queries;
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
    
    [HttpGet("get-notes")]
    public async Task<IEnumerable<NoteReadDto>> GetNotes([FromQuery] GetNotesQuery query) => await _mediator.Send(query);

    [HttpDelete("delete-note")]
    [ProducesResponseType(typeof(NoteReadDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(StatusCodeProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<NoteReadDto> DeleteNote([FromQuery] DeleteNoteCommand command) => await _mediator.Send(command);
}
