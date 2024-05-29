using Action = AutoTrading.Domain.Entities.Action;

namespace AutoTrading.Domain.Events.ActionEvent;

public class ActionCompletedEvent : BaseEvent
{
    public ActionCompletedEvent(Action item)
    {
        Item = item;
    }

    public Action Item { get; set; }
}