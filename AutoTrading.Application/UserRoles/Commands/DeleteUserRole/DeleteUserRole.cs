using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Events.UserRoleEvents;

namespace AutoTrading.Application.UserRoles.Commands.DeleteUserRole;

public record DeleteUserRoleCommand(long UserId, long RoleId) : IRequest;

public class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteUserRoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.UserRoles
            .FindAsync([request.UserId, request.RoleId], cancellationToken);

        Guard.Against.NotFound((request.UserId, request.RoleId), entity);

        _context.UserRoles.Remove(entity);
        
        entity.AddDomainEvent(new UserRoleDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}