namespace AutoTrading.Application.Codes.Commands.CreateCode;

public class CreateCodeCommandValidator : AbstractValidator<CreateCodeCommand>
{
    public CreateCodeCommandValidator()
    {
        RuleFor(v => v.CodeId)
            .GreaterThanOrEqualTo(0)
            .NotEmpty();

        RuleFor(v => v.CodeCategoryId)
            .GreaterThanOrEqualTo(0)
            .NotEmpty();

        RuleFor(v => v.Text)
            .MaximumLength(50)
            .NotEmpty();
    }
}