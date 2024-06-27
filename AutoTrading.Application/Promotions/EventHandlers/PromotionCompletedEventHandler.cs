using AutoTrading.Domain.Events.PromotionEvents;
using AutoTrading.Domain.Events.RoleEvents;
using Microsoft.Extensions.Logging;

namespace AutoTrading.Application.Promotions.EventHandlers;

public class PromotionCompletedEventHandler : INotificationHandler<PromotionCompletedEvent>
{
    private readonly ILogger<PromotionCompletedEventHandler> _logger;

    public PromotionCompletedEventHandler(ILogger<PromotionCompletedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(PromotionCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AutoTrading Domain Event: {DomainEvent}", notification.GetType().Name);
        
        return Task.CompletedTask;
    }
}