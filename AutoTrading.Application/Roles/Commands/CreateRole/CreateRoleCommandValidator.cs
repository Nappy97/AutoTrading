namespace AutoTrading.Application.Roles.Commands.CreateRole;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(r => r.Name)
            .MaximumLength(50)
            .NotEmpty();
    }
}