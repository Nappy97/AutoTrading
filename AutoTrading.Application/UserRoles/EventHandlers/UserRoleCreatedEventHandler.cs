using AutoTrading.Domain.Events.UserRoleEvents;
using Microsoft.Extensions.Logging;

namespace AutoTrading.Application.UserRoles.EventHandlers;

public class UserRoleCreatedEventHandler : INotificationHandler<UserRoleCreatedEvent>
{
    private readonly ILogger<UserRoleCreatedEvent> _logger;

    public UserRoleCreatedEventHandler(ILogger<UserRoleCreatedEvent> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(UserRoleCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AutoTrading Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}