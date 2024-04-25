using AutoTrading.Domain.Events.StockEvents;
using Microsoft.Extensions.Logging;

namespace AutoTrading.Application.Stocks.EventHandlers;

public class StockCreatedEventHandler : INotificationHandler<StockCreatedEvent>
{
    private readonly ILogger<StockCreatedEventHandler> _logger;

    public StockCreatedEventHandler(ILogger<StockCreatedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(StockCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AutoTrading Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}