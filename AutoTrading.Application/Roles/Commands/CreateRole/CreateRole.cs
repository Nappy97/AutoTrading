using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;
using AutoTrading.Domain.Events.RoleEvents;

namespace AutoTrading.Application.Roles.Commands.CreateRole;

public record CreateRoleCommand : IRequest<long>
{
    public string? Name { get; init; }
}

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, long>
{
    private readonly IApplicationDbContext _context;

    public CreateRoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<long> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = new Role
        {
            Name = request.Name
        };

        entity.AddDomainEvent(new RoleCreatedEvent(entity));

        _context.Roles.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}