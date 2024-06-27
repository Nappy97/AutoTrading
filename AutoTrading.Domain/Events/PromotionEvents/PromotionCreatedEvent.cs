namespace AutoTrading.Domain.Events.PromotionEvents;

public class PromotionCreatedEvent : BaseEvent
{
    public PromotionCreatedEvent(Promotion item)
    {
        Item = item;
    }

    public Promotion Item { get; }
}