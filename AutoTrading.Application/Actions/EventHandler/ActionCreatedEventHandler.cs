using AutoTrading.Domain.Events.ActionEvent;
using Microsoft.Extensions.Logging;

namespace AutoTrading.Application.Actions.EventHandler;

public class ActionCreatedEventHandler : INotificationHandler<ActionCreatedEvent>
{
    private readonly ILogger<ActionCreatedEventHandler> _logger;

    public ActionCreatedEventHandler(ILogger<ActionCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ActionCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AutoTrading Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}