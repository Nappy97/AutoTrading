namespace AutoTrading.Domain.Events.CodeEvents;

public class CodeCompletedEvent  : BaseEvent
{
    public CodeCompletedEvent(Code item)
    {
        Item = item;
    }
    
    public Code Item { get; }
}