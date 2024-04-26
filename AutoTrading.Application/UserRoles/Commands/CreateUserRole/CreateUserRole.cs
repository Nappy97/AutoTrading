using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;
using AutoTrading.Domain.Events.UserRoleEvents;

namespace AutoTrading.Application.UserRoles.Commands.CreateUserRole;

public record CreateUserRoleCommand : IRequest<long>
{
    public long UserId { get; init; }

    public long RoleId { get; init; }
}

public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, long>
{
    private readonly IApplicationDbContext _context;

    public CreateUserRoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<long> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = new UserRole
        {
            UserId = request.UserId,
            RoleId = request.RoleId
        };
        
        entity.AddDomainEvent(new UserRoleCreatedEvent(entity));

        _context.UserRoles.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}