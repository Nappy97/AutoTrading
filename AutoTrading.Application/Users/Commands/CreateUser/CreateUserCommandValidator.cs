namespace AutoTrading.Application.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        // TODO: 전제조건 검색 후 추가
        RuleFor(u => u.UserName)
            .MaximumLength(50)
            .MinimumLength(5)
            .NotEmpty();

        RuleFor(u => u.Password)
            .MinimumLength(5)
            .MaximumLength(50)
            .NotEmpty();
    }
}