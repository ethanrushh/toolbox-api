using MediatR;
using ToolKitAPI.Data.DTOs.Notes;

namespace ToolKitAPI.Core.Queries;

public record GetNotesQuery(int? Quantity) : IRequest<IEnumerable<NoteReadDto>>;