using AutoTrading.Application.Common.Interfaces;

namespace AutoTrading.Application.Actions.Commands.UpdateAction;

public record UpdateActionCommand : IRequest
{
    public long Id { get; init; }

    public string? Name { get; init; }

    public string? Memo { get; init; }
}

public class UpdateActionCommandHandler : IRequestHandler<UpdateActionCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateActionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateActionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Actions
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;
        entity.Memo = request.Memo;

        await _context.SaveChangesAsync(cancellationToken);
    }
}