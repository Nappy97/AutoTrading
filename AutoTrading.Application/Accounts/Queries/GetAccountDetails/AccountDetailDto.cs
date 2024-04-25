using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Accounts.Queries.GetAccountDetails;

public class AccountDetailDto
{
    public long Id { get; init; }

    public long AccountId { get; init; }

    public long StockId { get; init; }

    public int PurchasedPrice { get; init; }

    public int PurchasedQuantity { get; init; }

    public DateTime? PurchasedAt { get; init; }

    public int SoldPrice { get; init; }

    public int SoldQuantity { get; init; }

    public DateTime? SoldAt { get; init; }

    public int Profit { get; set; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AccountDetail, AccountDetailDto>();
        }
    }
}