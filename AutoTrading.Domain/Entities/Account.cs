namespace AutoTrading.Domain.Entities;

public class Account : BaseEntity 
{
    public long UserId { get; set; }
    
    /// <summary>
    /// [13] 증권사 이름
    /// </summary>
    public int StockFirmCode { get; set; }

    /// <summary>
    /// [14] 계좌 종류
    /// </summary>
    public int AccountTypeCode { get; set; }

    /// <summary>
    /// 계좌번호
    /// </summary>
    public string? AccountNumber { get; set; }

    /// <summary>
    /// 사용가능여부
    /// </summary>
    public bool Enabled { get; set; } = true;

    /// <summary>
    /// 현재 계좌 평가금액
    /// </summary>
    public int CurrentAmount { get; set; }

    /// <summary>
    /// 현재 현금보유
    /// </summary>
    public int CurrentCurrency { get; set; }

    /// <summary>
    /// 특이사항
    /// </summary>
    public string? Memo { get; set; }

    public User User { get; set; } = null!;
    
    public ICollection<AccountDetail> AccountDetails { get; private set; } = new List<AccountDetail>();
}