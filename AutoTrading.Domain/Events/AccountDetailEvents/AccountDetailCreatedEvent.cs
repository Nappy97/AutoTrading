namespace AutoTrading.Domain.Events.AccountDetailEvents;

public class AccountDetailCreatedEvent : BaseEvent
{
    public AccountDetailCreatedEvent(AccountDetail item)
    {
        Item = item;
    }

    public AccountDetail Item { get; }
}