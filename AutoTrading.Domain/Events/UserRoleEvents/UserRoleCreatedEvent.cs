namespace AutoTrading.Domain.Events.UserRoleEvents;

public class UserRoleCreatedEvent : BaseEvent
{
    public UserRoleCreatedEvent(UserRole item)
    {
        Item = item;
    }

    public UserRole Item { get; }
}