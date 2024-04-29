using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;
using AutoTrading.Domain.Events.AccountDetailEvents;

namespace AutoTrading.Application.AccountDetails.Commands.CreateAccountDetail;

public record CreateAccountDetailCommand : IRequest<long>
{
    public long UserId { get; init; }
    
    public long AccountId { get; init; }

    public long StockId { get; init; }

    public int PurchasedPrice { get; init; }

    public int PurchasedQuantity { get; init; }

    public DateTime? PurchasedAt { get; init; } = DateTime.Now;
}

public class CreateAccountDetailCommandHandler : IRequestHandler<CreateAccountDetailCommand, long>
{
    private readonly IApplicationDbContext _context;

    public CreateAccountDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<long> Handle(CreateAccountDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = new AccountDetail
        {
            AccountId = request.AccountId,
            StockId = request.StockId,
            PurchasedAt = request.PurchasedAt,
            PurchasedQuantity = request.PurchasedQuantity,
            PurchasedPrice = request.PurchasedPrice,
            //TradeCode = 거래
        };

        entity.AddDomainEvent(new AccountDetailCreatedEvent(entity));

        _context.AccountDetails.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

}