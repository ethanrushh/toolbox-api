using MediatR;
using ToolKitAPI.Core.Commands.Notes;
using ToolKitAPI.Data.DTOs.Notes;
using ToolKitAPI.Data.Models;
using ToolKitAPI.Data.Services;

namespace ToolKitAPI.Core.Handlers;

public class CreateNoteHandler : IRequestHandler<CreateNoteCommand, NoteReadDto>
{
    private readonly NotesService _notesService;

    public CreateNoteHandler(NotesService notesService)
    {
        _notesService = notesService;
    }
    
    public async Task<NoteReadDto> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var newNote = new NoteModel
        {
            Content = request.Content,
            Creator = request.Creator,
            LastModifiedUtc = DateTime.UtcNow
        };

        return await _notesService.CreateNote(newNote);
    }
}
