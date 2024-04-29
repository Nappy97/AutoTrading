using AutoTrading.Domain.Events.UserEvents;
using Microsoft.Extensions.Logging;

namespace AutoTrading.Application.Users.EventHandlers;

public class UserCompletedEventHandler : INotificationHandler<UserCompletedEvent>
{
    private readonly ILogger<UserCompletedEventHandler> _logger;

    public UserCompletedEventHandler(ILogger<UserCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(UserCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AutoTrading Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}