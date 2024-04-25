using AutoTrading.Domain.Events.CodeCategoryEvents;
using Microsoft.Extensions.Logging;

namespace AutoTrading.Application.CodeCategories.EventHandlers;

public class CodeCategoryCompletedEventHandler : INotificationHandler<CodeCategoryCompletedEvent>
{
    private readonly ILogger<CodeCategoryCompletedEventHandler> _logger;

    public CodeCategoryCompletedEventHandler(ILogger<CodeCategoryCompletedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(CodeCategoryCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AutoTrading Domain Event: {DomainEvent}", notification.GetType().Name);
        
        return Task.CompletedTask;
    }
}