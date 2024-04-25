using AutoTrading.Domain.Events.AccountDetailEvents;
using Microsoft.Extensions.Logging;

namespace AutoTrading.Application.AccountDetails.EventHandlers;

public class AccountDetailCompletedEventHandler : INotificationHandler<AccountDetailCompletedEvent>
{
    private readonly ILogger<AccountDetailCompletedEventHandler> _logger;

    public AccountDetailCompletedEventHandler(ILogger<AccountDetailCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(AccountDetailCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AutoTrading Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}