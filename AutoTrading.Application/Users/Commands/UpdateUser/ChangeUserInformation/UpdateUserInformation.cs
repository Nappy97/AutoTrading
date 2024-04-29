using AutoTrading.Application.Common.Interfaces;

namespace AutoTrading.Application.Users.Commands.UpdateUser.ChangeUserInformation;

public record UpdateUserInformationCommand : IRequest
{
    public long Id { get; init; }

    public string? Name { get; init; }
}

public class UpdateUserInformationCommandHandler : IRequestHandler<UpdateUserInformationCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateUserInformationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateUserInformationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Users
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);
    }
}