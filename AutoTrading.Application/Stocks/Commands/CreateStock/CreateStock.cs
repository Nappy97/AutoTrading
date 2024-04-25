using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;
using AutoTrading.Domain.Events.StockEvents;

namespace AutoTrading.Application.Stocks.Commands.CreateStock;

public record CreateStockCommand : IRequest<long>
{
    public string? Name { get; init; }
    public string? StockCode { get; init; }
    public int NationalityCode { get; init; }
    public int LocationCode { get; init; }
}

public class CreateStockCommandHandler : IRequestHandler<CreateStockCommand, long>
{
    private readonly IApplicationDbContext _context;

    public CreateStockCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<long> Handle(CreateStockCommand request, CancellationToken cancellationToken)
    {
        var entity = new Stock
        {
            Name = request.Name,
            StockCode = request.StockCode,
            NationalityCode = request.NationalityCode,
            LocationCode = request.LocationCode
        };

        entity.AddDomainEvent(new StockCreatedEvent(entity));

        _context.Stocks.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}