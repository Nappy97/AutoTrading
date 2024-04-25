namespace AutoTrading.Application.Accounts.Queries.GetAccountDetails;

public class AccountDetailsVm
{
    public IReadOnlyCollection<AccountDto> Lists { get; init; } = Array.Empty<AccountDto>();
}