using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Events.ActionRoleEvent;

namespace AutoTrading.Application.ActionRoles.Commands.DeleteActionRole;

public record DeleteActionRoleCommand(long ActionId, long RoleId) : IRequest;

public class DeleteActionRoleCommandHandler : IRequestHandler<DeleteActionRoleCommand>
{
    private IApplicationDbContext _context;

    public DeleteActionRoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(DeleteActionRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ActionRoles
            .FindAsync([request.ActionId, request.RoleId], cancellationToken);

        Guard.Against.NotFound((request.ActionId, request.RoleId), entity);

        _context.ActionRoles.Remove(entity);
        
        entity.AddDomainEvent(new ActionRoleDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}