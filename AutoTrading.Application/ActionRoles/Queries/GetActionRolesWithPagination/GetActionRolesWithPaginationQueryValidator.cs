namespace AutoTrading.Application.ActionRoles.Queries.GetActionRolesWithPagination;

public class GetActionRolesWithPaginationQueryValidator : AbstractValidator<GetActionRolesWithPaginationQuery>
{
    public GetActionRolesWithPaginationQueryValidator()
    {
        RuleFor(x => x.ActionId)
            .GreaterThanOrEqualTo(1);

        RuleFor(x => x.RoleId)
            .GreaterThanOrEqualTo(1);
        
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Page는 1보다 크거나 같아야 합니다.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Page의 개수는 1보다 크거나 작아야합니다");
    }
}