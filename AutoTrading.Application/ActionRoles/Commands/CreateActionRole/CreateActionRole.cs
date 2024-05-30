using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;
using AutoTrading.Domain.Events.ActionRoleEvent;

namespace AutoTrading.Application.ActionRoles.Commands.CreateActionRole;

public record CreateActionRoleCommand : IRequest<(long, long)>
{
    public long ActionId { get; init; }
    public long RoleId { get; init; }
}

public class CreateActionRoleCommandHandler : IRequestHandler<CreateActionRoleCommand, (long, long)>
{
    private readonly IApplicationDbContext _context;

    public CreateActionRoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<(long, long)> Handle(CreateActionRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = new ActionRole
        {
            ActionId = request.ActionId,
            RoleId = request.RoleId
        };
        
        entity.AddDomainEvent(new ActionRoleCreatedEvent(entity));

        _context.ActionRoles.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return (entity.ActionId, entity.RoleId);
    }
}