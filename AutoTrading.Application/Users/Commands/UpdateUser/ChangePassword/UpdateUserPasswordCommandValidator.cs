using AutoTrading.Application.Common.Interfaces;

namespace AutoTrading.Application.Users.Commands.UpdateUser.ChangePassword;

public class UpdateUserPasswordCommandValidator : AbstractValidator<UpdateUserPasswordCommandQuery>
{
    public UpdateUserPasswordCommandValidator()
    {
        RuleFor(u => u.NewPassword)
            .NotEmpty()
            .Must((u, newPassword) => 
                IsSamePassword(newPassword, u.ConfirmNewPassword))
            .WithMessage("비밀번호가 일치 하지 않습니다.")
            .MinimumLength(10)
            .WithMessage("비밀번호는 10자 이상 입력해주세요.");
    }

    private bool IsSamePassword(string? newPassword, string? confirmNewPassword)
    {
        return newPassword == confirmNewPassword;
    }
}