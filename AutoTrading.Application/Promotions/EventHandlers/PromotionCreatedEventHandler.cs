using AutoTrading.Domain.Events.PromotionEvents;
using AutoTrading.Domain.Events.RoleEvents;
using Microsoft.Extensions.Logging;

namespace AutoTrading.Application.Promotions.EventHandlers;

public class PromotionCreatedEventHandler : INotificationHandler<PromotionCreatedEvent>
{
    private readonly ILogger<PromotionCreatedEventHandler> _logger;

    public PromotionCreatedEventHandler(ILogger<PromotionCreatedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(PromotionCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AutoTrading Domain Event: {DomainEvent}", notification.GetType().Name);
        
        return Task.CompletedTask;
    }
}