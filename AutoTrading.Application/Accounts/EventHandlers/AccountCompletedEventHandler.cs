using AutoTrading.Domain.Events.AccountEvents;
using Microsoft.Extensions.Logging;

namespace AutoTrading.Application.Accounts.EventHandlers;

public class AccountCompletedEventHandler : INotificationHandler<AccountCompletedEvent>
{
    private readonly ILogger<AccountCompletedEventHandler> _logger;

    public AccountCompletedEventHandler(ILogger<AccountCompletedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(AccountCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AutoTrading Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}