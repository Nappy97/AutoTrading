namespace AutoTrading.Domain.Events.StockEvents;

public class StockCreatedEvent : BaseEvent
{
    public StockCreatedEvent(Stock item)
    {
        Item = item;
    }
    
    public Stock Item { get; }
}