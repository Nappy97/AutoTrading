using AutoTrading.Domain.Events.CodeEvents;
using Microsoft.Extensions.Logging;

namespace AutoTrading.Application.Codes.EventHandlers;

public class CodeCompletedEventHandler : INotificationHandler<CodeCompletedEvent>
{
    private readonly ILogger<CodeCompletedEventHandler> _logger;

    public CodeCompletedEventHandler(ILogger<CodeCompletedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(CodeCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AutoTrading Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}