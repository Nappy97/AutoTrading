namespace AutoTrading.Domain.Events.StockEvents;

public class StockDeletedEvent : BaseEvent
{
    public StockDeletedEvent(Stock item)
    {
        Item = item;
    }
    
    public Stock Item { get; }
}