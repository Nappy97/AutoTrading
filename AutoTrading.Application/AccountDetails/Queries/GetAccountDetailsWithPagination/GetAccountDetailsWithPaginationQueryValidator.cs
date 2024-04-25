namespace AutoTrading.Application.AccountDetails.Queries.GetAccountDetailsWithPagination;

public class GetAccountDetailsWithPaginationQueryValidator : AbstractValidator<GetAccountDetailsWithPaginationQuery>
{
    public GetAccountDetailsWithPaginationQueryValidator()
    {
        RuleFor(a => a.AccountId)
            .NotEmpty()
            .WithMessage("계좌가 잘못되었습니다");

        RuleFor(a => a.UserId)
            .NotEmpty()
            .WithMessage("유저 아이디를 확인해주세요");
        
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}