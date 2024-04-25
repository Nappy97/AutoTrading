
using AutoTrading.Domain.Events.AccountEvents;
using Microsoft.Extensions.Logging;

namespace AutoTrading.Application.Accounts.EventHandlers;

public class AccountCreatedEventHandler : INotificationHandler<AccountCreatedEvent>
{
    private readonly ILogger<AccountCreatedEventHandler> _logger;

    public AccountCreatedEventHandler(ILogger<AccountCreatedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(AccountCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AutoTrading Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}