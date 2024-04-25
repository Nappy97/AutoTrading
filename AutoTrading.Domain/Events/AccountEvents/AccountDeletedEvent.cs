namespace AutoTrading.Domain.Events.AccountEvents;

public class AccountDeletedEvent : BaseEvent
{
    public AccountDeletedEvent(Account item)
    {
        Item = item;
    }

    public Account Item { get; }
}