using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Events.CodeEvents;

namespace AutoTrading.Application.Codes.Commands.DeleteCode;

public record DeleteCodeCommand(int CodeId) : IRequest;

public class DeleteCodeCommandHandler : IRequestHandler<DeleteCodeCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCodeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteCodeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Codes
            .FindAsync([request.CodeId], cancellationToken);

        Guard.Against.NotFound(request.CodeId, entity);

        _context.Codes.Remove(entity);

        entity.AddDomainEvent(new CodeDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}