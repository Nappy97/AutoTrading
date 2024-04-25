namespace AutoTrading.Domain.Events.AccountDetailEvents;

public class AccountDetailDeletedEvent : BaseEvent
{
    public AccountDetailDeletedEvent(AccountDetail item)
    {
        Item = item;
    }
    
    public AccountDetail Item { get; }    
}