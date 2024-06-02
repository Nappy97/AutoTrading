using FluentValidation.Validators;

namespace AutoTrading.Application.Users.Register;

public record RegistrationResponse(bool Flag, string Message = null!);