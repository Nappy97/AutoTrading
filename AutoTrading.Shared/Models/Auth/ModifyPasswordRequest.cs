namespace AutoTrading.Shared.Models.Auth;

public record ModifyPasswordRequest(string OldPassword, string NewPassword, string PasswordConfirm);