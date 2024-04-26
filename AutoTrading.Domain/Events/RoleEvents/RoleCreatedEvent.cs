namespace AutoTrading.Domain.Events.RoleEvents;

public class RoleCreatedEvent : BaseEvent
{
    public RoleCreatedEvent(Role item)
    {
        Item = item;
    }

    public Role Item { get; }
}