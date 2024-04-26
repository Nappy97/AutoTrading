namespace AutoTrading.Domain.Events.RoleEvents;

public class RoleCompletedEvent : BaseEvent
{
    public RoleCompletedEvent(Role item)
    {
        Item = item;
    }

    public Role Item { get; }
}