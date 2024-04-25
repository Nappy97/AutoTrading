using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.AccountDetails.Queries.GetAccountDetailsWithPagination;

public class AccountDetailBriefDto
{
    public long Id { get; init; }

    public long StockId { get; init; }

    public long AccountId { get; init; }

    public int PurchasedPrice { get; init; }

    public int PurchasedQuantity { get; init; }

    public DateTime? PurchasedAt { get; init; }

    public int SoldPrice { get; init; }

    public int SoldQuantity { get; init; }

    public DateTime? SoldAt { get; init; }

    public int Profit { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AccountDetail, AccountDetailBriefDto>();
        }
    }
}