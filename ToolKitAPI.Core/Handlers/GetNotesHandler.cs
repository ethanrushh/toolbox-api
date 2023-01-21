using MediatR;
using ToolKitAPI.Core.Queries;
using ToolKitAPI.Data.DTOs.Notes;
using ToolKitAPI.Data.Services;

namespace ToolKitAPI.Core.Handlers;

public class GetNotesHandler : IRequestHandler<GetNotesQuery, IEnumerable<NoteReadDto>>
{
    private readonly NotesService _notesService;

    public GetNotesHandler(NotesService notesService)
    {
        _notesService = notesService;
    }
    
    public async Task<IEnumerable<NoteReadDto>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
    {
        return await _notesService.GetAllNotes(request.Quantity ?? int.MaxValue);
    }
}
