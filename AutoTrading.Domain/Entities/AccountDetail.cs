namespace AutoTrading.Domain.Entities;

public class AccountDetail : BaseEntity
{
    public long AccountId { get; set; }

    public long StockId { get; set; }

    /// <summary>
    /// 개당 구매 가격
    /// </summary>
    public int PurchasedPrice { get; set; }

    /// <summary>
    /// 구매 수량
    /// </summary>
    public int PurchasedQuantity { get; set; }

    /// <summary>
    /// 구매 시각
    /// </summary>
    public DateTime? PurchasedAt { get; set; }
    
    /// <summary>
    /// 개당 판매 가격
    /// </summary>
    public int SoldPrice { get; set; }

    /// <summary>
    /// 판매 수량
    /// </summary>
    public int SoldQuantity { get; set; }

    /// <summary>
    /// 판매 시각
    /// </summary>
    public DateTime? SoldAt { get; set; }

    /// <summary>
    /// 수익(수수료, 세금제외)
    /// </summary>
    public int Profit { get; set; }

    /// <summary>
    /// [15] 매매 구분
    /// </summary>
    public int TradeCode { get; set; }

    public string? Memo { get; set; }

    public Account Account { get; set; } = null!;

    public Stock Stock { get; set; } = null!;
}