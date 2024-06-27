namespace AutoTrading.Domain.Events.PromotionEvents;

public class PromotionDeletedEvent : BaseEvent
{
    public PromotionDeletedEvent(Promotion item)
    {
        Item = item;
    }
    
    public Promotion Item { get; }    
}