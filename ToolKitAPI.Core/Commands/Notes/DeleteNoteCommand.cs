using MediatR;
using ToolKitAPI.Data.DTOs.Notes;

namespace ToolKitAPI.Core.Commands.Notes;

public record DeleteNoteCommand(Guid Id) : IRequest<NoteReadDto>;