namespace AutoTrading.Domain.Events.ActionRoleEvent;

public class ActionRoleDeletedEvent : BaseEvent
{
    public ActionRoleDeletedEvent(ActionRole item)
    {
        Item = item;
    }

    public ActionRole Item { get; set; }
}