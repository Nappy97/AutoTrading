namespace AutoTrading.Application.Accounts.Commands.UpdateAccount;

public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
{
    public UpdateAccountCommandValidator()
    {
        RuleFor(v => v.Enabled)
            .NotEmpty();

        RuleFor(v => v.Memo)
            .MaximumLength(200);

        RuleFor(v => v.CurrentAmount)
            .GreaterThan(0)
            .NotEmpty();

        RuleFor(v => v.CurrentCurrency)
            .GreaterThan(0)
            .NotEmpty();
    }
}