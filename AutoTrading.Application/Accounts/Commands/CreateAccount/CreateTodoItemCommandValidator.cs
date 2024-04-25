namespace AutoTrading.Application.Accounts.Commands.CreateAccount;

public class CreateTodoItemCommandValidator : AbstractValidator<CreateAccountCommand>
{
    public CreateTodoItemCommandValidator()
    {
        RuleFor(v => v.UserId)
            .NotEmpty();

        RuleFor(v => v.AccountNumber)
            .MaximumLength(200)
            .NotEmpty();

        RuleFor(v => v.AccountTypeCode)
            .NotEmpty()
            .WithMessage("");

        RuleFor(v => v.StockFirmCode)
            .NotEmpty()
            .WithMessage("");
    }
}