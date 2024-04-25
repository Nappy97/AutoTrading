using AutoTrading.Domain.Events.StockEvents;
using Microsoft.Extensions.Logging;

namespace AutoTrading.Application.Stocks.EventHandlers;

public class StockCompletedEventHandler : INotificationHandler<StockCompletedEvent>
{
    private readonly ILogger<StockCompletedEventHandler> _logger;

    public StockCompletedEventHandler(ILogger<StockCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(StockCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AutoTrading Domain Event: {DomainEvent}", notification.GetType().Name);
        
        return Task.CompletedTask;
    }
}