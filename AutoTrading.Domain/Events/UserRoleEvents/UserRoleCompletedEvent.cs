namespace AutoTrading.Domain.Events.UserRoleEvents;

public class UserRoleCompletedEvent : BaseEvent
{
    public UserRoleCompletedEvent(UserRole item)
    {
        Item = item;
    }

    public UserRole Item { get; }
}