namespace AutoTrading.Domain.Events.CodeEvents;

public class CodeCreatedEvent : BaseEvent
{
    public CodeCreatedEvent(Code item)
    {
        Item = item;
    }
    
    public Code Item { get; }
}