using MediatR;
using ToolKitAPI.Data.DTOs.Notes;

namespace ToolKitAPI.Core.Commands.Notes;

public record CreateNoteCommand(string Creator, string Content) : IRequest<NoteReadDto>;