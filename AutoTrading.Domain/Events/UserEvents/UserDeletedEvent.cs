namespace AutoTrading.Domain.Events.UserEvents;

public class UserDeletedEvent : BaseEvent
{
    public UserDeletedEvent(User item)
    {
        Item = item;
    }

    public User Item { get; }
}