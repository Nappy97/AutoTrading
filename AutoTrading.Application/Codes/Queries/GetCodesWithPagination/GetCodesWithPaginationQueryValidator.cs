namespace AutoTrading.Application.Codes.Queries.GetCodesWithPagination;

public class GetCodesWithPaginationQueryValidator : AbstractValidator<GetCodesWithPaginationQuery>
{
    public GetCodesWithPaginationQueryValidator()
    {
        RuleFor(x => x.CodeCategoryId)
            .NotEmpty()
            .WithMessage("코드 카테고리 ID는 필수 입니다.");

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Page는 1보다 크거나 같아야 합니다.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Page의 개수는 1보다 크거나 작아야합니다");
    }
}