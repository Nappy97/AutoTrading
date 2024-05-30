using AutoTrading.Domain.Events.ActionEvent;
using Microsoft.Extensions.Logging;

namespace AutoTrading.Application.Actions.EventHandler;

public class ActionCompletedEventHandler : INotificationHandler<ActionCompletedEvent>
{
    private readonly ILogger<ActionCompletedEventHandler> _logger;

    public ActionCompletedEventHandler(ILogger<ActionCompletedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(ActionCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AutoTrading Domain Event: {DomainEvent}", notification.GetType().Name);
        
        return Task.CompletedTask;
    }
}