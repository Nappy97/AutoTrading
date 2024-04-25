namespace AutoTrading.Domain.Events.CodeCategoryEvents;

public class CodeCategoryDeletedEvent : BaseEvent
{
    public CodeCategoryDeletedEvent(CodeCategory item)
    {
        Item = item;
    }
    
    public CodeCategory Item { get; }
}