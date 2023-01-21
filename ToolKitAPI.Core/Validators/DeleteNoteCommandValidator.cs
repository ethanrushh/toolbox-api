using FluentValidation;
using ToolKitAPI.Core.Commands.Notes;

namespace ToolKitAPI.Core.Validators;

public class DeleteNoteCommandValidator : AbstractValidator<DeleteNoteCommand>
{
    public DeleteNoteCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}