using AutoMapper;
using ToolKitAPI.Data.Contexts;
using ToolKitAPI.Data.DTOs.Notes;
using ToolKitAPI.Data.Models;

namespace ToolKitAPI.Data.Services;

public class NotesService
{
    private readonly NotesContext _dbContext;
    private readonly IMapper _mapper;

    public NotesService(NotesContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }


    public async Task<NoteReadDto> CreateNote(NoteModel newNote)
    {
        var addedNote = await _dbContext.AddAsync(newNote);

        await _dbContext.SaveChangesAsync();

        return _mapper.Map<NoteReadDto>(addedNote.Entity);
    }
}
