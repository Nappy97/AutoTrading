using AutoTrading.Application.Common.Interfaces;

namespace AutoTrading.Application.AccountDetails.Commands.UpdateSoldAccountDetail;

public record UpdateSoldAccountDetailCommand : IRequest
{
    public long Id { get; init; }

    public int SoledPrice { get; init; }

    public int SoledQuantity { get; init; }

    public DateTime? SoledAt { get; init; } = DateTime.Now;
}

public class UpdateSoldAccountDetailCommandHandler : IRequestHandler<UpdateSoldAccountDetailCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateSoldAccountDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateSoldAccountDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.AccountDetails
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.SoldPrice = request.SoledPrice;
        entity.SoldQuantity = request.SoledQuantity;
        entity.SoldAt = request.SoledAt;
        
        // TODO: 해당 코드표 추가 후 수정
        // TODO: 2024 04 23 Validator 작성해야함
        //entity.TradeCode = "매도";
        entity.Profit = entity.SoldQuantity * entity.SoldQuantity - entity.SoldPrice * entity.SoldQuantity;

        await _context.SaveChangesAsync(cancellationToken);
    }
}