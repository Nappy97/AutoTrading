using Action = AutoTrading.Domain.Entities.Action;

namespace AutoTrading.Domain.Events.ActionEvent;

public class ActionCreatedEvent : BaseEvent
{
    public ActionCreatedEvent(Action item)
    {
        Item = item;
    }

    public Action Item { get; set; }
}