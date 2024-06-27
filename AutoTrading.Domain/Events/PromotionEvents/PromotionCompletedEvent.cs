namespace AutoTrading.Domain.Events.PromotionEvents;

public class PromotionCompletedEvent : BaseEvent
{
    public PromotionCompletedEvent(Promotion item)
    {
        Item = item;
    }
    
    public Promotion Item { get; }
}