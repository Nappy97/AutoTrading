namespace AutoTrading.Domain.Events.StockEvents;

public class StockCompletedEvent : BaseEvent
{
    public StockCompletedEvent(Stock item)
    {
        Item = item;
    }
    
    public Stock Item { get; }
}