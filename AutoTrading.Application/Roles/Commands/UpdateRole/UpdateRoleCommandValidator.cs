namespace AutoTrading.Application.Roles.Commands.UpdateRole;

public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(r => r.Id)
            .GreaterThanOrEqualTo(1)
            .NotEmpty();

        RuleFor(r => r.Name)
            .MaximumLength(50)
            .NotEmpty();
    }
}