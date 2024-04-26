namespace AutoTrading.Domain.Events.UserRoleEvents;

public class UserRoleDeletedEvent : BaseEvent
{
    public UserRoleDeletedEvent(UserRole item)
    {
        Item = item;
    }

    public UserRole Item { get; }
}