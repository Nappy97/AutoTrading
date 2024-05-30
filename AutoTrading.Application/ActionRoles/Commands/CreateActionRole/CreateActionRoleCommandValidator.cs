namespace AutoTrading.Application.ActionRoles.Commands.CreateActionRole;

public class CreateActionRoleCommandValidator : AbstractValidator<CreateActionRoleCommand>
{
    public CreateActionRoleCommandValidator()
    {
        RuleFor(a => a.ActionId)
            .GreaterThanOrEqualTo(1)
            .NotEmpty();

        RuleFor(a => a.RoleId)
            .GreaterThanOrEqualTo(1)
            .NotEmpty();
    }   
}