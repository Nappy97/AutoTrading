namespace AutoTrading.Application.Actions.Commands.CreateAction;

public class CreateActionCommandValidator : AbstractValidator<CreateActionCommand>
{
    public CreateActionCommandValidator()
    {
        RuleFor(a => a.Name)
            .MaximumLength(50)
            .NotEmpty();

        RuleFor(a => a.Memo)
            .MaximumLength(50);
    }
}