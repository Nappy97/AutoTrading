namespace AutoTrading.Application.ActionRoles.Commands.UpdateActionRole;

public class UpdateActionRoleCommandValidator : AbstractValidator<UpdateActionRoleCommand>
{
    public UpdateActionRoleCommandValidator()
    {
        RuleFor(a => a.ActionId)
            .GreaterThanOrEqualTo(1)
            .NotEmpty();

        RuleFor(a => a.RoleId)
            .GreaterThanOrEqualTo(1)
            .NotEmpty();
    }
}