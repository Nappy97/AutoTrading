using AutoTrading.Application.Common.Interfaces;

namespace AutoTrading.Application.Users.Commands.UpdateUser.ChangePassword;

public class UpdateUserPasswordCommandValidator : AbstractValidator<UpdateUserPasswordCommand>
{
    public UpdateUserPasswordCommandValidator()
    {
        RuleFor(u => u.NewPassword)
            .NotEmpty()
            .Must((u, newPassword) => 
                IsSamePassword(newPassword, u.ConfirmNewPassword))
            .WithMessage("'{PropertyName}'은 해당 유저의 계좌가 아닙니다.")
            .MinimumLength(10)
            .WithMessage("비밀번호는 10자 이상 입력해주세요.");
    }

    private bool IsSamePassword(string? newPassword, string? confirmNewPassword)
    {
        return newPassword == confirmNewPassword;
    }
}