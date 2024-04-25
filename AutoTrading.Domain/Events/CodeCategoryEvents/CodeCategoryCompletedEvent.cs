namespace AutoTrading.Domain.Events.CodeCategoryEvents;

public class CodeCategoryCompletedEvent : BaseEvent
{
    public CodeCategoryCompletedEvent(CodeCategory item)
    {
        Item = item;
    }
    
    public CodeCategory Item { get; }
}