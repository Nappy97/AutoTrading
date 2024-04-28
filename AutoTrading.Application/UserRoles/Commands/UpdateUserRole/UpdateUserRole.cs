using AutoTrading.Application.Common.Interfaces;

namespace AutoTrading.Application.UserRoles.Commands.UpdateUserRole;

public record UpdateUserRoleCommand : IRequest
{
    public long UserId { get; init; }

    public long RoleId { get; init; }
}

public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateUserRoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.UserRoles
            .FindAsync([request.UserId, request.RoleId], cancellationToken);

        Guard.Against.NotFound((request.UserId, request.RoleId), entity);

        entity.UserId = request.UserId;
        entity.RoleId = request.RoleId;

        await _context.SaveChangesAsync(cancellationToken);
    }
}