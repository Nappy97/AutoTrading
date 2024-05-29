using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Events.ActionEvent;
using AutoTrading.Domain.Events.RoleEvents;

namespace AutoTrading.Application.Actions.Commands.DeleteAction;

public record DeleteActionCommand(long Id) : IRequest;

public class DeleteActionCommandHandler : IRequest<DeleteActionCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteActionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteActionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Actions
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Actions.Remove(entity);

        entity.AddDomainEvent(new ActionDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}