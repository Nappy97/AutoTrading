using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Accounts.Queries.GetAccountDetails;

public class AccountDto
{
    public AccountDto()
    {
        Items = Array.Empty<AccountDetailDto>();
    }
    
    public long Id { get; init; }

    public int StockFirmCode { get; init; }

    public int AccountTypeCode { get; init; }

    public string? AccountNumber { get; init; }

    public int CurrentAmount { get; init; }

    public int CurrentCurrency { get; init; }

    public IReadOnlyCollection<AccountDetailDto> Items { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Account, AccountDto>();
        }
    }
}