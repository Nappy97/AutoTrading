using AutoTrading.Domain.Events.RoleEvents;
using Microsoft.Extensions.Logging;

namespace AutoTrading.Application.Roles.EventHandlers;

public class RoleCreatedEventHandler : INotificationHandler<RoleCreatedEvent>
{
    private readonly ILogger<RoleCreatedEventHandler> _logger;

    public RoleCreatedEventHandler(ILogger<RoleCreatedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(RoleCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AutoTrading Domain Event: {DomainEvent}", notification.GetType().Name);
        
        return Task.CompletedTask;
    }
}