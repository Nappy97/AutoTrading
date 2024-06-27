using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;
using AutoTrading.Domain.Events.PromotionEvents;

namespace AutoTrading.Application.Promotions.Commands.DeletePromotion;

public record DeletePromotionCommand(long Id) : IRequest;

public class DeletePromotionCommandHandler : IRequestHandler<DeletePromotionCommand>
{
    private readonly IApplicationDbContext _context;

    public DeletePromotionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Promotions
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Promotions.Remove(entity);
        
        entity.AddDomainEvent(new PromotionDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}