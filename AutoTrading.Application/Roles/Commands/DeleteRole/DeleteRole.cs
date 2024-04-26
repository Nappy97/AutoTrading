using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Events.RoleEvents;

namespace AutoTrading.Application.Roles.Commands.DeleteRole;

public record DeleteRoleCommand(long Id) : IRequest;

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteRoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Roles
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Roles.Remove(entity);
        
        entity.AddDomainEvent(new RoleDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}