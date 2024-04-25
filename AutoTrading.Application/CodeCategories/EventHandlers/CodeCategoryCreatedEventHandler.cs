using AutoTrading.Domain.Events.CodeCategoryEvents;
using Microsoft.Extensions.Logging;

namespace AutoTrading.Application.CodeCategories.EventHandlers;

public class CodeCategoryCreatedEventHandler : INotificationHandler<CodeCategoryCreatedEvent>
{
    private readonly ILogger<CodeCategoryCreatedEventHandler> _logger;

    public CodeCategoryCreatedEventHandler(ILogger<CodeCategoryCreatedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(CodeCategoryCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AutoTrading Domain Event: {DomainEvent}", notification.GetType().Name);
        
        return Task.CompletedTask;
    }
}