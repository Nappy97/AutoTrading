using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Events.UserEvents;

namespace AutoTrading.Application.Users.Commands.DeleteUser;

public record DeleteUserCommand(long Id) : IRequest;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Users
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Users.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}