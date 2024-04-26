namespace AutoTrading.Application.UserRoles.Commands.CreateUserRole;

public class CreateUserRoleValidator : AbstractValidator<CreateUserRoleCommand>
{
    public CreateUserRoleValidator()
    {
        RuleFor(u => u.UserId)
            .GreaterThanOrEqualTo(1)
            .NotEmpty();

        RuleFor(u => u.RoleId)
            .GreaterThanOrEqualTo(1)
            .NotEmpty();
    }
}