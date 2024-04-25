using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Events.StockEvents;

namespace AutoTrading.Application.Stocks.Commands.DeleteStock;

public record DeleteStockCommand(long Id) : IRequest;

public class DeleteStockCommandHandler : IRequestHandler<DeleteStockCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteStockCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(DeleteStockCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Stocks
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Stocks.Remove(entity);
        
        entity.AddDomainEvent(new StockDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}