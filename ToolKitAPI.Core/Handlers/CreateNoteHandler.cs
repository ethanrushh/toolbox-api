using MediatR;
using ToolKitAPI.Core.Commands.Notes;
using ToolKitAPI.Data.DTOs.Notes;

namespace ToolKitAPI.Core.Handlers;

public class CreateNoteHandler : IRequestHandler<CreateNoteCommand, NoteReadDto>
{
    public Task<NoteReadDto> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        
    }
}