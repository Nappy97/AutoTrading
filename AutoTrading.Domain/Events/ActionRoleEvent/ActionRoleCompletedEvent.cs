namespace AutoTrading.Domain.Events.ActionRoleEvent;

public class ActionRoleCompletedEvent : BaseEvent
{
    public ActionRoleCompletedEvent(ActionRole item)
    {
        Item = item;
    }

    public ActionRole Item { get; set; }
}