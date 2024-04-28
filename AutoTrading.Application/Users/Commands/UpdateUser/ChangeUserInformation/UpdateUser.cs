using AutoTrading.Application.Common.Interfaces;

namespace AutoTrading.Application.Users.Commands.UpdateUser.ChangeUserInformation;

public record UpdateUserCommand : IRequest
{
    public long Id { get; init; }

    public string? Name { get; init; }
}

public class UpdateUser : IRequestHandler<UpdateUserCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateUser(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Users
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);
    }
}