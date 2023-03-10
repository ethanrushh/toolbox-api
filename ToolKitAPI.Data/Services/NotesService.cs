using System.Collections.Immutable;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToolKitAPI.Core.Exceptions;
using ToolKitAPI.Data.Contexts;
using ToolKitAPI.Data.DTOs.Notes;
using ToolKitAPI.Data.Models;

namespace ToolKitAPI.Data.Services;

// TODO Create an interface that reflects the required endpoints for DI
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

    public async Task<IEnumerable<NoteReadDto>> GetAllNotes(int quantity)
    {
        var notes = await _dbContext.Notes.Take(quantity).ToListAsync();

        return _mapper.Map<IEnumerable<NoteReadDto>>(notes);
    }

    public async Task<NoteReadDto> DeleteNote(Guid id)
    {
        var note = await _dbContext.Notes.FirstOrDefaultAsync(x => x.Id == id);

        if (note is default(NoteModel))
            throw new NotFoundInDatabaseException($"Note with ID {id} was not found in database");

        _dbContext.Notes.Remove(note);

        await _dbContext.SaveChangesAsync();

        return _mapper.Map<NoteReadDto>(note);
    }
}
