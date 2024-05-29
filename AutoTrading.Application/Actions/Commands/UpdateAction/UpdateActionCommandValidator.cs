namespace AutoTrading.Application.Actions.Commands.UpdateAction;

public class UpdateActionCommandValidator : AbstractValidator<UpdateActionCommand>
{
    public UpdateActionCommandValidator()
    {
        RuleFor(a => a.Id)
            .GreaterThanOrEqualTo(1)
            .NotEmpty();

        RuleFor(a => a.Name)
            .MaximumLength(50)
            .NotEmpty();

        RuleFor(a => a.Memo)
            .MaximumLength(50);
    }
}