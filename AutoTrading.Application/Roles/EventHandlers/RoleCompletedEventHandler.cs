using AutoTrading.Domain.Events.RoleEvents;
using Microsoft.Extensions.Logging;

namespace AutoTrading.Application.Roles.EventHandlers;

public class RoleCompletedEventHandler : INotificationHandler<RoleCompletedEvent>
{
    private readonly ILogger<RoleCompletedEventHandler> _logger;

    public RoleCompletedEventHandler(ILogger<RoleCompletedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(RoleCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AutoTrading Domain Event: {DomainEvent}", notification.GetType().Name);
        
        return Task.CompletedTask;
    }
}