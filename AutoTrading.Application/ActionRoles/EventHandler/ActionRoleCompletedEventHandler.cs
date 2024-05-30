using AutoTrading.Domain.Events.ActionRoleEvent;
using Microsoft.Extensions.Logging;

namespace AutoTrading.Application.ActionRoles.EventHandler;

public class ActionRoleCompletedEventHandler : INotificationHandler<ActionRoleCompletedEvent>
{
    private readonly ILogger<ActionRoleCompletedEventHandler> _logger;

    public ActionRoleCompletedEventHandler(ILogger<ActionRoleCompletedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(ActionRoleCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AutoTrading Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}