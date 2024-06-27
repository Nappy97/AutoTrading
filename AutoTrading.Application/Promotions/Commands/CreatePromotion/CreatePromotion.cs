using System.ComponentModel.DataAnnotations;
using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;
using AutoTrading.Domain.Events.PromotionEvents;
using AutoTrading.Domain.Events.RoleEvents;

namespace AutoTrading.Application.Promotions.Commands.CreatePromotion;

public record CreatePromotionCommand : IRequest<long>
{
    public string? PromotionName { get; init; }

    public DateTime? StartedAt { get; init; }

    public DateTime? FinishedAt { get; init; }

    public string? ImagePath { get; init; }
}

public class CreatePromotionCommandHandler : IRequestHandler<CreatePromotionCommand, long>
{
    private readonly IApplicationDbContext _context;

    public CreatePromotionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<long> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
    {
        var entity = new Promotion
        {
            PromotionName = request.PromotionName,
            ImagePath = request.ImagePath,
            StartedAt = request.StartedAt,
            FinishedAt = request.FinishedAt
        };

        entity.AddDomainEvent(new PromotionCreatedEvent(entity));

        _context.Promotions.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}