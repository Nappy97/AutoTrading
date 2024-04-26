namespace AutoTrading.Domain.Events.RoleEvents;

public class RoleDeletedEvent : BaseEvent
{
    public RoleDeletedEvent(Role item)
    {
        Item = item;
    }

    public Role Item { get; }
}