using AutoTrading.Application.Common.Interfaces;

namespace AutoTrading.Application.Stocks.Commands.UpdateStock;

public record UpdateStockCommand : IRequest
{
    public long Id { get; init; }
    public bool Enabled { get; init; }
    public string? Memo { get; set; }
}

public class UpdateStockCommandHandler : IRequestHandler<UpdateStockCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateStockCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateStockCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Stocks
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Enabled = request.Enabled;
        entity.Memo = request.Memo;

        await _context.SaveChangesAsync(cancellationToken);
    }
}