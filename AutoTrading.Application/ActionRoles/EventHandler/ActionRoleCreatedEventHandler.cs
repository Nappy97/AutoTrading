using AutoTrading.Domain.Events.ActionEvent;
using AutoTrading.Domain.Events.ActionRoleEvent;
using Microsoft.Extensions.Logging;

namespace AutoTrading.Application.ActionRoles.EventHandler;

public class ActionRoleCreatedEventHandler : INotificationHandler<ActionCreatedEvent>
{
    private readonly ILogger<ActionRoleCreatedEventHandler> _logger;

    public ActionRoleCreatedEventHandler(ILogger<ActionRoleCreatedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(ActionCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AutoTrading Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}