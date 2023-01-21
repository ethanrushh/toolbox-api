using FluentValidation;
using ToolKitAPI.Core.Commands.Notes;

namespace ToolKitAPI.Core.Validators;

public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
{
    public CreateNoteCommandValidator()
    {
        RuleFor(x => x.Content).NotEmpty().NotNull();
        RuleFor(x => x.Creator).NotEmpty().NotNull();
    }
}
