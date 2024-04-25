namespace AutoTrading.Domain.Events.AccountDetailEvents;

public class AccountDetailCompletedEvent : BaseEvent
{
    public AccountDetailCompletedEvent(AccountDetail item)
    {
        Item = item;
    }
    
    public AccountDetail Item { get; }
}