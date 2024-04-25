namespace AutoTrading.Application.Stocks.Commands.CreateStock;

public class CreateStockCommandValidator : AbstractValidator<CreateStockCommand>
{
    public CreateStockCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(50)
            .NotEmpty();

        RuleFor(v => v.NationalityCode)
            .InclusiveBetween(1100, 1199)
            .NotEmpty();

        RuleFor(v => v.LocationCode)
            .InclusiveBetween(1200, 1299)
            .NotEmpty();

        RuleFor(v => v.StockCode)
            .MaximumLength(30)
            .NotEmpty();
    }
}