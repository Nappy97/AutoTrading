using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Users.Commands.UpdateUser.ChangePassword;

public record UpdateUserPasswordCommandQuery(User User) : IRequest
{
    public string? OldPassword { get; init; }

    public string? NewPassword { get; init; }

    public string? ConfirmNewPassword { get; init; }
}

public class UpdateUserPasswordCommandHandler : IRequestHandler<UpdateUserPasswordCommandQuery>
{
    private readonly IApplicationDbContext _context;

    public UpdateUserPasswordCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateUserPasswordCommandQuery request, CancellationToken cancellationToken)
    {
        request.User.Password = request.NewPassword;
        await _context.SaveChangesAsync(cancellationToken);
    }
}