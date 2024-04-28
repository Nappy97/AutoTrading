using AutoTrading.Domain.Events.UserRoleEvents;
using Microsoft.Extensions.Logging;

namespace AutoTrading.Application.UserRoles.EventHandlers;

public class UserRoleCompletedEventHandler : INotificationHandler<UserRoleCompletedEvent>
{
    private readonly ILogger<UserRoleCompletedEventHandler> _logger;

    public UserRoleCompletedEventHandler(ILogger<UserRoleCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(UserRoleCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AutoTrading Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}