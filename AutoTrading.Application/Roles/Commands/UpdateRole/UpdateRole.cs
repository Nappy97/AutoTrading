using AutoTrading.Application.Common.Interfaces;

namespace AutoTrading.Application.Roles.Commands.UpdateRole;

public record UpdateRoleCommand : IRequest
{
    public long Id { get; init; }

    public string? Name { get; init; }
}

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateRoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Roles
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);
    }
}