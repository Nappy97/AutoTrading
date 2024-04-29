using AutoTrading.Application.Common.Interfaces;

namespace AutoTrading.Application.Users.Commands.UpdateUser.ChangePassword;

public record UpdateUserPasswordCommand : IRequest
{
    public long Id { get; init; }

    public string? OldPassword { get; init; }

    public string? NewPassword { get; init; }

    public string? ConfirmNewPassword { get; init; }
}

public class UpdateUserPasswordCommandHandler : IRequestHandler<UpdateUserPasswordCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateUserPasswordCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Users
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);
        
        //if(entity.Password != request.OldPassword)

        entity.Password = request.NewPassword;

        await _context.SaveChangesAsync(cancellationToken);
    }
    
    private async Task<bool> IsOwnAccount(long userId, long accountId, CancellationToken cancellationToken = default)
    {
        return await _context.Accounts
            .AnyAsync(account => account.Id == accountId && account.UserId == userId, cancellationToken);
    }
}