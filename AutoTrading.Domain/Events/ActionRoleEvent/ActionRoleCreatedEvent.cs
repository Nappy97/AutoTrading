namespace AutoTrading.Domain.Events.ActionRoleEvent;

public class ActionRoleCreatedEvent : BaseEvent
{
    public ActionRoleCreatedEvent(ActionRole item)
    {
        Item = item;
    }

    public ActionRole Item { get; set; }
}