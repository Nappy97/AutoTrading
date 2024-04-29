namespace AutoTrading.Application.Users.Commands.UpdateUser.ChangeUserInformation;

public class UpdateUserInformationCommandValidator : AbstractValidator<UpdateUserInformationCommand>
{
    public UpdateUserInformationCommandValidator()
    {
        RuleFor(u => u.Name)
            .MinimumLength(2)
            .MaximumLength(10)
            .NotEmpty();
    }
}