using MediatR;
using ToolKitAPI.Core.Commands.Notes;
using ToolKitAPI.Data.DTOs.Notes;
using ToolKitAPI.Data.Services;

namespace ToolKitAPI.Core.Handlers;

public class DeleteNoteHandler : IRequestHandler<DeleteNoteCommand, NoteReadDto>
{
    private readonly NotesService _notesService;

    public DeleteNoteHandler(NotesService notesService)
    {
        _notesService = notesService;
    }
    
    public async Task<NoteReadDto> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        return await _notesService.DeleteNote(request.Id);
    }
}