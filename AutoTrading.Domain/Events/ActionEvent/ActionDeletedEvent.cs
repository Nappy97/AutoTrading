using Action = AutoTrading.Domain.Entities.Action;

namespace AutoTrading.Domain.Events.ActionEvent;

public class ActionDeletedEvent : BaseEvent
{
    public ActionDeletedEvent(Action item)
    {
        Item = item;
    }

    public Action Item { get; set; }
}