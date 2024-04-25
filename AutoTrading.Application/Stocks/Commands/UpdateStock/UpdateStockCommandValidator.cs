namespace AutoTrading.Application.Stocks.Commands.UpdateStock;

public class UpdateStockCommandValidator : AbstractValidator<UpdateStockCommand>
{
    public UpdateStockCommandValidator()
    {
        RuleFor(v => v.Enabled)
            .NotEmpty();

        RuleFor(v => v.Memo)
            .MaximumLength(200);
    }
}