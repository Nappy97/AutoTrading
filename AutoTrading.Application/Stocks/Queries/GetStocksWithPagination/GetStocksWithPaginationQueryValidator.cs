namespace AutoTrading.Application.Stocks.Queries.GetStocksWithPagination;

public class GetStocksWithPaginationQueryValidator : AbstractValidator<GetStocksWithPaginationQuery>
{
    public GetStocksWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Page Number는 1보다 크거나 같아야합니다");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1)
            .WithMessage("페이지 Size는 1보다 크거나 같아야합니다.");
    }
}