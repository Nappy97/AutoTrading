using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Promotions.Commands.UpdatePromotion;

public record UpdatePromotionCommand : IRequest
{
    public long Id { get; init; }
    
    public string? PromotionName { get; init; }

    public DateTime? StartedAt { get; init; }

    public DateTime? FinishedAt { get; init; }

    public string? ImagePath { get; init; }
}

public class UpdatePromotionCommandHandler : IRequestHandler<UpdatePromotionCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdatePromotionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Promotions
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.PromotionName = request.PromotionName;
        entity.StartedAt = request.StartedAt;
        entity.FinishedAt = request.FinishedAt;
        entity.ImagePath = request.ImagePath;

        await _context.SaveChangesAsync(cancellationToken);
    }
}