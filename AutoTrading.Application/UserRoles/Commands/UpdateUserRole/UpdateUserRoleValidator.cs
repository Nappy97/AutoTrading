namespace AutoTrading.Application.UserRoles.Commands.UpdateUserRole;

public class UpdateUserRoleValidator : AbstractValidator<UpdateUserRoleCommand>
{
    public UpdateUserRoleValidator()
    {
        RuleFor(u => u.UserId)
            .GreaterThanOrEqualTo(1)
            .NotEmpty();

        RuleFor(u => u.RoleId)
            .GreaterThanOrEqualTo(1)
            .NotEmpty();
    }
}