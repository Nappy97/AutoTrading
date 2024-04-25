namespace AutoTrading.Domain.Events.CodeEvents;

public class CodeDeletedEvent : BaseEvent
{
    public CodeDeletedEvent(Code item)
    {
        Item = item;
    }
    
    public Code Item { get; }
}