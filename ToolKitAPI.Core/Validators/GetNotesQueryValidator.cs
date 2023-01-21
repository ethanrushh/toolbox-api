using FluentValidation;
using ToolKitAPI.Core.Queries;

namespace ToolKitAPI.Core.Validators;

public class GetNotesQueryValidator : AbstractValidator<GetNotesQuery>
{
    public GetNotesQueryValidator()
    {
        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .When(x => x.Quantity is not null);
    }
}
