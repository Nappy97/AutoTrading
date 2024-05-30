using System.Diagnostics;
using AutoTrading.Application.Common.Interfaces;

namespace AutoTrading.Application.ActionRoles.Commands.UpdateActionRole;

public record UpdateActionRoleCommand : IRequest
{
    public long ActionId { get; init; }

    public long RoleId { get; init; }
}

public class UpdateActionRoleCommandHandler : IRequestHandler<UpdateActionRoleCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateActionRoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(UpdateActionRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ActionRoles
            .FindAsync([request.ActionId, request.RoleId], cancellationToken);

        Guard.Against.NotFound((request.ActionId, request.RoleId), entity);

        entity.ActionId = request.ActionId;
        entity.RoleId = request.RoleId;

        await _context.SaveChangesAsync(cancellationToken);
    }
}