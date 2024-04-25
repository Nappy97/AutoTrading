namespace AutoTrading.Domain.Events.AccountEvents;

public class AccountCreatedEvent : BaseEvent
{
    public AccountCreatedEvent(Account item)
    {
        Item = item;
    }

    public Account Item { get; }
}