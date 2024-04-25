namespace AutoTrading.Domain.Events.CodeCategoryEvents;

public class CodeCategoryCreatedEvent : BaseEvent
{
    public CodeCategoryCreatedEvent(CodeCategory item)
    {
        Item = item;
    }
    
    public CodeCategory Item { get; }
}