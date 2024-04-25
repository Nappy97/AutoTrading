namespace AutoTrading.Application.Codes.Commands.UpdateCode;

public class UpdateCodeCommandValidator : AbstractValidator<UpdateCodeCommand>
{
    public UpdateCodeCommandValidator()
    {
        RuleFor(v => v.Text)
            .MaximumLength(50)
            .NotEmpty();

        RuleFor(v => v.Enabled)
            .NotEmpty();
    }
}