namespace AutoTrading.Domain.Events.AccountEvents;

public class AccountCompletedEvent : BaseEvent
{
    public AccountCompletedEvent(Account item)
    {
        Item = item;
    }
    
    public Account Item { get; }
}